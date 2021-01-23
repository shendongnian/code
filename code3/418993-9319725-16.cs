    public static Bitmap Copy32BPPBitmapSafe(Bitmap srcBitmap)
    {
        Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);
        Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
        BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
        BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);
        Int64 srcScan0 = srcData.Scan0.ToInt64();
        Int64 resScan0 = resData.Scan0.ToInt64();
        int srcStride = srcData.Stride;
        int resStride = resData.Stride;
        int rowLength = Math.Abs(srcData.Stride);
        try
        {
            byte[] buffer = new byte[rowLength];
            for (int y = 0; y < srcData.Height; y++)
            {
                Marshal.Copy(new IntPtr(srcScan0 + y * srcStride), buffer, 0, rowLength);
                Marshal.Copy(buffer, 0, new IntPtr(resScan0 + y * resStride), rowLength);
            }
        }
        finally
        {
            srcBitmap.UnlockBits(srcData);
            result.UnlockBits(resData);
        }
        return result;
    }
