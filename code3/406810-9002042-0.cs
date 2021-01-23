    private unsafe void ApplyContrast(double contrast, Bitmap bmp)
    {
        byte[] contrast_lookup = new byte[256];
        double newValue = 0;
        double c = (100.0 + contrast) / 100.0;
        c *= c;
        for (int i = 0; i < 256; i++)
        {
            newValue = (double)i;
            newValue /= 255.0;
            newValue -= 0.5;
            newValue *= c;
            newValue += 0.5;
            newValue *= 255;
            if (newValue < 0)
                newValue = 0;
            if (newValue > 255)
                newValue = 255;
            contrast_lookup[i] = (byte)newValue;
        }
        var bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), 
            System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        int PixelSize = 4;
        for (int y = 0; y < bitmapdata.Height; y++)
        {
            byte* destPixels = (byte*)bitmapdata.Scan0 + (y * bitmapdata.Stride);
            for (int x = 0; x < bitmapdata.Width; x++)
            {
                destPixels[x * PixelSize] = contrast_lookup[destPixels[x * PixelSize]]; // B
                destPixels[x * PixelSize + 1] = contrast_lookup[destPixels[x * PixelSize + 1]]; // G
                destPixels[x * PixelSize + 2] = contrast_lookup[destPixels[x * PixelSize + 2]]; // R
                //destPixels[x * PixelSize + 3] = contrast_lookup[destPixels[x * PixelSize + 3]]; //A
            }
        }
        bmp.UnlockBits(bitmapdata);
    }
