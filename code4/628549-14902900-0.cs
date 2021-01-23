    System.Drawing.Imaging.BitmapData data = null;
    data = bitmap.LockBits
    (
        new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly,
        System.Drawing.Imaging.PixelFormat.Format32bppArgb
    );
    // For later usage
    var imageStride = data.Stride;
    var imageHeight = data.Height;
    // allocate space to hold the data
    byte[] buffer = new byte[data.Stride * data.Height];
    // Source will be the bitmap scan data
    IntPtr pointer = data.Scan0;
    // the CLR marshalling system knows how to move blocks of bytes around, FAST.
    Marshal.Copy(pointer, buffer, 0, buffer.Length);
    // and now we can unlock this since we don't need it anymore
    bitmap.UnlockBits(data);
    ComputeHistogram(buffer, imageStride, imageHeight, parallel);
