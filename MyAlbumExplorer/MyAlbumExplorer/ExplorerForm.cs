using System;
using System.Collections.Generic;
using System.IO;
using Manning.MyPhotoAlbum;
using Manning.MyPhotoControls;
using System.Windows.Forms;

namespace MyAlbumExplorer
{
    public partial class ExplorerForm : Form
    {
        private Photograph _currentPhoto = null;
        public ExplorerForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Assign title bar
            Version v = new Version(Application.
            ProductVersion);
            this.Text = String.Format(
            "MyAlbumExplorer {0:#}.{1:#}",
            v.Major, v.Minor);
            atvAlbumTree.Nodes.Clear();
            atvAlbumTree.AddAlbumDirectory(
            "Default Albums",
            AlbumManager.DefaultPath);
            base.OnLoad(e);
        }
        private void atvAlbumTree_BeforeSelect(object sender,TreeViewCancelEventArgs e)
        {
            if (_currentPhoto != null)
            {
                spbxPhoto.Image = null;
                _currentPhoto.ReleaseImage();
                _currentPhoto = null;
            }
        }
        private void atvAlbumTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is PhotoNode)
                DisplayPhoto(e.Node as PhotoNode);
        }
        private void DisplayPhoto(PhotoNode photoNode)
        {
            _currentPhoto = photoNode.Photograph;
            spbxPhoto.Image = _currentPhoto.Image;
        }
    }
}
