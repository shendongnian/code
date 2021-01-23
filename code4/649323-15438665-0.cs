    using (var bmp = new Bitmap(fileName))
    {
        using (var output = new Bitmap(
            bmp.Width + 4, bmp.Height + 4, bmp.PixelFormat))
        using (var g = Graphics.FromImage(output))
        {
            g.DrawImage(bmp, 0, 0, output.Width, output.Height);
            output.Save(outFileName, ImageFormat.Png);
        }
    }
