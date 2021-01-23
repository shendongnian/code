    BitmapImage bi = new BitmapImage();
    WriteableBitmap wbm = new WriteableBitmap(bi);
    int w = wbm.PixelWidth;
    int h = wbm.PixelHeight;
    int[] p = wbm.Pixels;
    int len = p.Length;
    byte[] result = new byte[4 * w * h];
    // Copy pixels to buffer
    for (int i = 0, j = 0; i < len; i++, j += 4)
    {
        int color = p[i];
        result[j + 0] = (byte)(color >> 24); // A
        result[j + 1] = (byte)(color >> 16); // R
        result[j + 2] = (byte)(color >> 8);  // G
        result[j + 3] = (byte)(color);       // B
    }
