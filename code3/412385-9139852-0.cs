    public class customUserControl : UserControl
    {
        //Store image as a Uri rather than an Image
        private Uri StoredImagePath;
        public class PictureBoxAdv : PictureBox
        {
            public PictureBoxAdv()
            {
                this.VisibleChanged +=new EventHandler(VisibleChanged);
            }
        }
        public Uri Image
        {
            get { return StoredImagePath; }
            set
            {
                StoredImagePath = value;
                if (this.Visible && StoredImagePath != null)
                {
                    this.Image = Image.FromFile(StoredImagePath.AbsolutePath);
                }
            }
        }
        public void VisibleChanged(object sender, EventArgs e)
        {
            //When becomes visible, restore image, invisible, nullify.
            if (this.Visible && StoredImagePath != null)
            {
                this.Image = Image.FromFile(StoredImagePath.AbsolutePath);
            }
            else
            {
                this.Image = null;
            }
        }
    }
