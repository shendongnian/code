    public unsafe static Bitmap GetAlphaBitmap(Bitmap srcBitmap)
    {
        Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);
        Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
        BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
        BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);
         int* srcScan0 = (int*)srcData.Scan0;
         int* resScan0 = (int*)resData.Scan0;
         int numPixels = srcData.Stride / 4 * srcData.Height;
         try
         {
             for (int p = 0; p < numPixels; p++)
             {
                 *(resScan0 + p) = *(srcScan0 + p);
             }
         }
         finally
         {
             srcBitmap.UnlockBits(srcData);
             result.UnlockBits(resData);
         }
        return result;
    }
