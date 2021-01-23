    var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    var bmpData =
        bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
        bmp.PixelFormat);
    IntPtr ptr = bmpData.Scan0;
    byte* bmpBytes = (byte*)ptr.ToPointer();
