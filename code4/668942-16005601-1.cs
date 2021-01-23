        public Form1() {
            InitializeComponent();
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox2.AllowDrop = true;
            pictureBox2.DragEnter += pictureBox2_DragEnter;
            pictureBox2.DragDrop += pictureBox2_DragDrop;
        }
        void pictureBox2_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void pictureBox2_DragDrop(object sender, DragEventArgs e) {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pictureBox2.Image = bmp;
        }
