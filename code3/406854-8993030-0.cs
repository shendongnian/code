    using (System.Drawing.Bitmap _bitmap = new System.Drawing.Bitmap(W_FixedSize, H_FixedSize))
    {
    _bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
    using (Graphics _graphic = Graphics.FromImage(_bitmap))
    {
        _graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        _graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        _graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        _graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //Code used to crop
        _graphic.DrawImage(img, 0, 0, w, h);
        _graphic.DrawImage(img, new Rectangle(0, 0, w, h), x, y, w, h, GraphicsUnit.Pixel);
        //Code I used to resize
        _graphic.DrawImage(img, 0, 0, img.Width, img.Height);
        _graphic.DrawImage(img, new Rectangle(0, 0, W_FixedSize, H_FixedSize), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
       //continued...
    }
}
