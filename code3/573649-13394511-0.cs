    public partial class MyPictureViewer : UserControl
    {
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        public MyPictureViewer()
        {
            InitializeComponent();
        }
        void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (pFileNames.Length > 0)
            {
                pCurrentImage = pCurrentImage == 0 ? pFileNames.Length - 1 : --pCurrentImage;
                ShowCurrentImage();
            }
        }
        void btnNextImage_Click(object sender, EventArgs e)
        {
            if (pFileNames.Length > 0)
            {
                pCurrentImage = pCurrentImage == pFileNames.Length - 1 ? 0 : ++pCurrentImage;
                ShowCurrentImage();
            }
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JPEG|*.jpg|Bitmaps|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pFileNames = openFileDialog.FileNames;
                pCurrentImage = 0;
                ShowCurrentImage();
            }
        }
        protected void ShowCurrentImage()
        {
            if (pCurrentImage >= 0 && pCurrentImage <= pFileNames.Length - 1)
            {
                pictureBox1.Image = Bitmap.FromFile(pFileNames[pCurrentImage]);
            }
        }
    }
