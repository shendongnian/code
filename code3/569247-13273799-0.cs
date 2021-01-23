    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    System.Drawing.Imaging.BitmapData bmpData =
      bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
    IntPtr ptr = bmpData.Scan0;
    int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
    byte[] rgbValues = new byte[bytes];
    // Copy the RGB values into the array.
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
    // do something with the array
    // Copy the RGB values back to the bitmap
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
    bmp.UnlockBits(bmpData);
