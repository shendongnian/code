    public static Image Rescale(Image image, int dpiX, int dpiY)
    {
        Bitmap bm = new Bitmap((int)(image.Width * dpiX / image.HorizontalResolution), (int)(image.Height * dpiY / image.VerticalResolution));
        bm.SetResolution(dpiX, dpiY);
        Graphics g = Graphics.FromImage(bm);
        g.InterpolationMode = InterpolationMode.Bicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.DrawImage(image, 0, 0);
        g.Dispose();
    
        return bm;
    }
