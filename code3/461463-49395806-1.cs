    using (MemoryStream ms = new MemoryStream(wordBytes))
    {
        float width = 3840;
        float height = 2160;
        var brush = new SolidBrush(Color.White);
        var rawImage = Image.FromStream(ms);
        float scale = Math.Min(width / rawImage.Width, height / rawImage.Height);
        var scaleWidth  = (int)(rawImage.Width  * scale);
        var scaleHeight = (int)(rawImage.Height * scale);
        var scaledBitmap = new Bitmap(scaleWidth, scaleHeight);
        
        Graphics graph = Graphics.FromImage(scaledBitmap);
        graph.InterpolationMode = InterpolationMode.High;
        graph.CompositingQuality = CompositingQuality.HighQuality;
        graph.SmoothingMode = SmoothingMode.AntiAlias;
        graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
        graph.DrawImage(rawImage, new Rectangle(0, 0 , scaleWidth, scaleHeight));
        
        scaledBitmap.Save(fileName, ImageFormat.Png);
        return scaledBitmap;
    }
