    BitmapSource bmp = BitmapFrame.Create(
        new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg", UriKind.Relative),
        BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
    if (bmp.Format != PixelFormats.Bgra32)
        bmp = new FormatConvertedBitmap(bmp, PixelFormats.Bgra32, null, 1);
        // Just ignore the last parameter
    WriteableBitmap wbmp = new WriteableBitmap(bmp.PixelWidth, bmp.PixelHeight,
        kbmp.DpiX, bmp.DpiY, bmp.Format, bmp.Palette);
    Int32Rect r = new Int32Rect(0, 0, bmp.PixelWidth, bmp.PixelHeight);
    wbmp.Lock();
    bmp.CopyPixels(r, wbmp.BackBuffer, wbmp.BackBufferStride * wbmp.PixelHeight,
        wbmp.BackBufferStride);
    wbmp.AddDirtyRect(r);
    wbmp.Unlock();
