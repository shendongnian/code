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
            for (int p = 0; p < numBytes; p += 4)
            {
                Marshal.WriteInt32(resScan0, p, Marshal.ReadInt32(srcScan0, p));
            }
        }
        finally
        {
            srcBitmap.UnlockBits(srcData);
            result.UnlockBits(resData);
        }
        return result;
    }
