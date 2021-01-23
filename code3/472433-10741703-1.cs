        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            //draw to the bitmap named buffer
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.DrawRectangle(Pens.Blue, 10, 10, 20, 20);
            }
            //assign the picturebox image to buffer
            pictureBox1.Image = buffer;
            //Now this will show the blue rectangle
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rectangle bounds = new Rectangle(Left, Top, Width, Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            this.BackgroundImage = bmp;
        }
