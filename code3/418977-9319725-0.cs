    public unsafe static Bitmap GetAlphaBitmap(Bitmap srcBitmap)
    {
        Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);
        Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
        BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
        BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);
        int* srcScan0 = (int*)srcData.Scan0;
        int* resScan0 = (int*)resData.Scan0;
        int w = srcData.Stride / 4;
        int h = srcData.Height;
        try
        {
            for (int y = 0; y < h; y++)
            {
                int* srcRow = srcScan0 + w * y;
                int* resRow = resScan0 + w * y;
                for (int x = 0; x < w; x++)
                {
                   *(resRow + x) = *(srcRow + x);
                }
            }
        }
        finally
        {
            srcBitmap.UnlockBits(srcData);
            result.UnlockBits(resData);
        }
        return result;
    }
