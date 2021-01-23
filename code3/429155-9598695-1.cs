    // test image
    BitmapImage image = new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"));
    // copy to byte array
    int stride = image.PixelWidth * 4;
    byte[] buffer = new byte[stride * image.PixelHeight];
    image.CopyPixels(buffer, stride, 0);
    // create bitmap
    System.Drawing.Bitmap bitmap =
        new System.Drawing.Bitmap(
            image.PixelWidth,
            image.PixelHeight,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    // lock bitmap data
    System.Drawing.Imaging.BitmapData bitmapData =
        bitmap.LockBits(
            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.ImageLockMode.WriteOnly,
            bitmap.PixelFormat);
    // copy byte array to bitmap data
    System.Runtime.InteropServices.Marshal.Copy(
        buffer, 0, bitmapData.Scan0, buffer.Length);
    // unlock
    bitmap.UnlockBits(bitmapData);
 
