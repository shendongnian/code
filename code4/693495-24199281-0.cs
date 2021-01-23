    public static Bitmap ContrastStretch(Bitmap srcImage, double blackPointPercent = 0.02, double whitePointPercent = 0.01)
    {
        BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, srcImage.Width, srcImage.Height), ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);
        Bitmap destImage = new Bitmap(srcImage.Width, srcImage.Height);
        BitmapData destData = destImage.LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        int stride = srcData.Stride;
        IntPtr srcScan0 = srcData.Scan0;
        IntPtr destScan0 = destData.Scan0;
        var freq = new int[256];
        unsafe
        {
            byte* src = (byte*) srcScan0;
            for (int y = 0; y < srcImage.Height; ++y)
            {
                for (int x = 0; x < srcImage.Width; ++x)
                {
                    ++freq[src[y*stride + x*4]];
                }
            }
            int numPixels = srcImage.Width*srcImage.Height;
            int minI = 0;
            var blackPixels = numPixels*blackPointPercent;
            int accum = 0;
            while (minI < 255)
            {
                accum += freq[minI];
                if (accum > blackPixels) break;
                ++minI;
            }
            int maxI = 255;
            var whitePixels = numPixels*whitePointPercent;
            accum = 0;
            while (maxI > 0)
            {
                accum += freq[maxI];
                if (accum > whitePixels) break;
                --maxI;
            }
            double spread = 255d/(maxI - minI);
            byte* dst = (byte*) destScan0;
            for (int y = 0; y < srcImage.Height; ++y)
            {
                for (int x = 0; x < srcImage.Width; ++x)
                {
                    int i = y*stride + x*4;
                    byte val = (byte) Clamp(Math.Round((src[i] - minI)*spread), 0, 255);
                    dst[i] = val;
                    dst[i + 1] = val;
                    dst[i + 2] = val;
                    dst[i + 3] = 255;
                }
            }
        }
        srcImage.UnlockBits(srcData);
        destImage.UnlockBits(destData);
        return destImage;
    }
    static double Clamp(double val, double min, double max)
    {
        return Math.Min(Math.Max(val, min), max);
    }
