        Image bgImage;
        public Form1()
        {
            InitializeComponent();
            bgImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(bgImage, new Point(0, 0));
        }
