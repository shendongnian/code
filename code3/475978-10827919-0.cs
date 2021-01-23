    var bmp = new Bitmap(300, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    using(Graphics g = Graphics.FromImage(bmp)) {
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        System.Windows.Forms.TextRenderer.DrawText(g, 
            @"low image quality when draw text on it", Font, new Point(10, 10), Color.Black);
    }
