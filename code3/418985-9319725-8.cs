    public static Bitmap Clone32BPPBitmapSafe(Bitmap srcBitmap)
    {
        Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);
        Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
        BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
        BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);
        IntPtr srcScan0 = srcData.Scan0;
        IntPtr resScan0 = resData.Scan0;
        int numBytes = srcData.Stride * srcData.Height;
        try
        {
            byte[] buffer = new byte[numBytes];
            Marshal.Copy(srcScan0, buffer, 0, numBytes);
            Marshal.Copy(buffer, 0, resScan0, numBytes);
        }
        finally
        {
            srcBitmap.UnlockBits(srcData);
            result.UnlockBits(resData);
        }
        return result;
    }
