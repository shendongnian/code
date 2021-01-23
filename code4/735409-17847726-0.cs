    private void image_Click(object sender, EventArgs e)
        {
            float y = (float)Cursor.Position.Y -50;
            float x = (float)Cursor.Position.X -50;
            Bitmap b = new Bitmap(@"C:\Users\Dozer789\Downloads\notepad-png.bmp");
            RectangleF r = new RectangleF(x, y, 0, 0);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.DrawString("yourText", new Font("Thaoma", 8), Brushes.Black, r);
            g.Flush();
            image.Image = b;
        }
