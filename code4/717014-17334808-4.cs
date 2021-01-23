    Image newImage = new Bitmap(newWidth, newHeight);
    using (Graphics g = Graphics.FromImage(newImage))
    {
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(uploaded, 0, 0, newWidth, newHeight);
    }
