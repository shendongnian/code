    System.Drawing.Bitmap bmpImage = new System.Drawing.Bitmap(inputImage);
    BitmapData bitmapData = bmpImage.LockBits(new Rectangle(0, 0, bmpImage.Width, bmpImage.Height), ImageLockMode.ReadOnly, inputImage.PixelFormat);
    IntPtr srcBmpPtr = bitmapData.Scan0;
    int bitsPerPixel = Image.GetPixelFormatSize(inputImage.PixelFormat);
    int srcIMGBytesSize = bitmapData.Stride * bitmapData.Height;
    byte[] byteSrcImage2DData = new byte[srcIMGBytesSize];
    Marshal.Copy(srcBmpPtr, byteSrcImage2DData, 0, srcIMGBytesSize);
    float[] srcImage2DData = new float[srcIMGBytesSize];
    Array.Copy(byteSrcImage2DData, srcImage2DData,srcIMGBytesSize);   //Exception at this line
    bmpImage.UnlockBits(bitmapData);
