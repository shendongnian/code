        bool ismouseDown = false;
        Point p;
        int Xdiff, Ydiff;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = (Bitmap)Image.FromFile(@"C:\..\YourImage.jpg");
            pictureBox1.Image = bmp;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.Text = Xdiff.ToString() + " - " + Ydiff.ToString();
            e.Graphics.DrawEllipse(Pens.Black, p.X - Xdiff, p.Y - Ydiff, Xdiff * 2, Ydiff * 2);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismouseDown = true;
            p = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismouseDown)
            {
                Xdiff = p.X > e.X ? p.X - e.X : e.X - p.X;
                Ydiff = p.Y > e.Y ? p.Y - e.Y : e.Y - p.Y;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismouseDown = false;
        }
