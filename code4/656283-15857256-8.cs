    using (Bitmap myBitmap = new Bitmap(102, 302))
    {
        Graphics g = Graphics.FromImage(myBitmap);
        g.Clear(Color.Transparent);
        g.FillEllipse(new SolidBrush(Color.FromArgb(0, Color.Red)), new Rectangle(1, 1, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(0, Color.Black)), new Rectangle(1, 51, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(0, Color.White)), new Rectangle(1, 101, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(64, Color.Red)), new Rectangle(51, 1, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(64, Color.Black)), new Rectangle(51, 51, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(64, Color.White)), new Rectangle(51, 101, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(128, Color.Red)), new Rectangle(1, 151, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(128, Color.Black)), new Rectangle(1, 201, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(128, Color.White)), new Rectangle(1, 251, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(255, Color.Red)), new Rectangle(51, 151, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(255, Color.Black)), new Rectangle(51, 201, 50, 50));
        g.FillEllipse(new SolidBrush(Color.FromArgb(255, Color.White)), new Rectangle(51, 251, 50, 50));
        g.DrawRectangle(Pens.Black, 0, 0, myBitmap.Width - 1, myBitmap.Height - 1);
        e.Graphics.DrawImage(myBitmap, 0, 0);
        ColorMatrix colorMatrix = new ColorMatrix(
            new Single[][]
            {
                new [] { 1f, 0, 0, 0, 0 },
                new [] { 0f, 1, 0, 0, 0 },
                new [] { 0f, 0, 1, 0, 0 },
                new [] { 0f, 0, 0, 1, 0 },
                new [] { 1f, 0, 0, 0, 1 }
            });
        using (ImageAttributes imageAttr = new ImageAttributes())
        {
            imageAttr.SetColorMatrix(colorMatrix);
            Rectangle rect = new Rectangle(150, 0, myBitmap.Width, myBitmap.Height);
            e.Graphics.DrawImage(myBitmap, rect, 0, 0, myBitmap.Width, myBitmap.Height, GraphicsUnit.Pixel, imageAttr);
        }
    }
