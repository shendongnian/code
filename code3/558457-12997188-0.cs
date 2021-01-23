     public bool isMouseDown { get; set; }
            Point lastPoint = Point.Empty;
            public double treshold { get; set; }
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (isMouseDown)
                {
                    pictureBox1.Capture = true; // I try to capture mouse here
                    Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle);
                    if (Math.Sqrt(Math.Pow(e.X - lastPoint.X, 2) + Math.Pow(e.Y - lastPoint.Y, 2)) > treshold)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (e.X + lastPoint.X)/2, (e.Y + lastPoint.Y)/2, 1, 1);
                       
                    }
                   
                    g.FillRectangle(new SolidBrush(Color.Black), e.X, e.Y, 1, 1);
                    lastPoint = new Point(e.X, e.Y);
                }
            }
    
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                isMouseDown = true;
                lastPoint = new Point(e.X, e.Y);
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                isMouseDown = false;
            }
