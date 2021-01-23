        private Graphics _graphics;
        private Pen _pen;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pX = e.X;
            pY = e.Y;
            _graphics =  = Graphics.FromImage(b);
            _pen= new Pen(Color.Black, 3);
            paint = true;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                _graphics.DrawLine(_pen, pX, pY, e.X, e.Y);
                pictureBox1.BackgroundImage = b;
                pX = e.X;
                pY = e.Y;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            _graphics.Dispose();
            _pen.Dispose();
        }
