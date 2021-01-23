        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int angle = 90;
            Graphics g = e.Graphics;
            Image i = new Bitmap(@"C:\Jellyfish.jpg");
            g.TranslateTransform((float)i.Width / 2, (float)i.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)i.Width / 2, -(float)i.Height / 2);
            g.DrawImage(i, new Point(0,0));
            
        }
