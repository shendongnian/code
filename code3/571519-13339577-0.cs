      public void drawRectangle(double Width, double Height, int A, bool pre_defined)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
       
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(Color.FromArgb(r.Next(0, 251), r.Next(0, 251), r.Next(0, 251)));
            Pen myPen = new Pen(brush, 2);
            myPen.Width = 2;
            int x = center.X;
            int y = center.Y;
            //top left
            P[0] = new PointF((float)Math.Round(x + (Width / 2) * Math.Cos(A) + (Height / 2) * Math.Sin(A)), (float)Math.Round(y - (Height / 2) * Math.Cos(A) + (Width / 2) * Math.Sin(A)));
            //top right
            P[1] = new PointF((float)Math.Round(x - (Width / 2) * Math.Cos(A) + (Height / 2) * Math.Sin(A)), (float)Math.Round(y - (Height / 2) * Math.Cos(A) - (Width / 2) * Math.Sin(A)));
            //bottom left
            P[2] = new PointF((float)Math.Round(x + (Width / 2) * Math.Cos(A) - (Height / 2) * Math.Sin(A)), (float)Math.Round(y + (Height / 2) * Math.Cos(A) + (Width / 2) * Math.Sin(A)));
            //bottom right
            P[3] = new PointF((float)Math.Round(x - (Width / 2) * Math.Cos(A) - (Height / 2) * Math.Sin(A)), (float)Math.Round(y + (Height / 2) * Math.Cos(A) - (Width / 2) * Math.Sin(A)));
            if (!pre_defined)
            {
                g.SetClip(new Rectangle(50, 50, 600, 300));
            }
            g.DrawLine(myPen, P[0], P[1]);
            g.DrawLine(myPen, P[1], P[3]);
            g.DrawLine(myPen, P[3], P[2]);
            g.DrawLine(myPen, P[2], P[0]);
        }
