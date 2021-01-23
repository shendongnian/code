            Image img = pictureBox1.Image;
            Graphics g = Graphics.FromImage(img);
            g.DrawEllipse(Pens.DarkBlue, new Rectangle(50, 25, 1, 1));
            g.DrawImage(img, new Point(0, 0));
            img.Save("d:\\img.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
