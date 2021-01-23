            Rectangle bounds = new Rectangle(10, 20, 50, 60);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty,Point.Empty, bounds.Size);
            bitmap.Save("d:\\img.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
