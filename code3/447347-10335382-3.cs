    System.Drawing.Bitmap bmp;
    Image image;
    ...
    using (var ms = new MemoryStream())
    {
        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        ms.Position = 0;
        var bi = new BitmapImage();
        bi.BeginInit();
        bi.CacheOption = BitmapCacheOption.OnLoad;
        bi.StreamSource = ms;
        bi.EndInit();
    }
    image.Source = bi;
    //bmp.Dispose(); //if bmp is not used further. Thanks @Peter
