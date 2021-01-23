    Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    BitmapData bmpData =
       bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
    
    int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
    byte[] rgbValues = new byte[bytes];
    
    // Copy the RGB values into the array.
    Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
