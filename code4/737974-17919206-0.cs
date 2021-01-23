    Bitmap bmpOriginal = Bitmap.FromFile("path_to_file");
    Bitmap bmpResampled = new Bitmap(newWidth, newHeight);
    Graphics g = Graphics.FromImage(bmpResampled);
    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
    g.DrawImage(bmpOriginal, new Rectangle(0, 0, bmpResampled.Width + 1, bmpResampled.Height + 1));
