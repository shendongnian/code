            Bitmap b = new Bitmap(200, 100);
            Graphics g = Graphics.FromImage(b);
            g.DrawString("My sample string", new Font("Tahoma",10), Brushes.Red, new Point(0, 0));
            b.Save("mypic.png", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            b.Dispose();
