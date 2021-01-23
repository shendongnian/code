    public static byte[] GetBytesWithMarshaling(Bitmap bitmap)
    {
        int height = bitmap.Height;
        int width = bitmap.Width;
        //PixelFormat.Format24bppRgb => B|G|R => 3 x 1 byte
        //Lock the image
        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        // 3 bytes per pixel
        int numberOfBytes = width * height * 3;
        byte[] imageBytes = new byte[numberOfBytes];
        //Get the pointer to the first scan line
        IntPtr sourcePtr = bmpData.Scan0;
        Marshal.Copy(sourcePtr, imageBytes, 0, numberOfBytes);
           
        //Unlock the image
        bitmap.UnlockBits(bmpData);
        return imageBytes;
    }
