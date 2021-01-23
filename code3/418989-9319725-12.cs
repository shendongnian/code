    public static Bitmap Copy32BPPBitmapSafe(Bitmap srcBitmap)
    {
        Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);
        Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
        BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
        BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);
        IntPtr srcScan0 = srcData.Scan0;
        IntPtr resScan0 = resData.Scan0;
        int stride = srcData.Stride;
        int rowLength = Math.Abs(srcData.Stride);
        try
        {
            byte[] buffer = new byte[rowLength];
            for (int y = 0; y < srcData.Height; y++)
            {
                Marshal.Copy(new IntPtr(srcScan0.ToInt64() + y * stride), buffer, 0, rowLength);
                Marshal.Copy(buffer, 0, new IntPtr(resScan0.ToInt64() + y * resData.Stride), rowLength);
            }
        }
        finally
        {
            srcBitmap.UnlockBits(srcData);
            result.UnlockBits(resData);
        }
        return result;
