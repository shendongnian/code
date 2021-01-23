    var bmp24bppRgb = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
    
    using (var g = Graphics.FromImage(bmp24bppRgb))
    {
      g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
    }
