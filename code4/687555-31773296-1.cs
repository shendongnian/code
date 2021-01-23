    Bitmap bmp = new Bitmap(@"Image.png");
    Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
    alpha = 128
    using (Graphics g = Graphics.FromImage(bmp)) {
        using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.Black))) {
            g.FillRectangle(cloud_brush, r);
        }
    }
    bmp.Save(@"Dark.png");
