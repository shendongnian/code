    private void processPixels()
    {
        Bitmap bmp = null;
        using (FileStream fs = new FileStream(@"C:\folder\SomeFileName.png", FileMode.Open))
        {
            bmp = (Bitmap)Image.FromStream(fs);
        }
        BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
        for (int i = 0; i < bmp.Height; i++)
        {
            for (int j = 0; j < bmp.Width; j++)
            {
                Color c = getPixel(bmd, j, i);
                //Do something with pixel here
            }
        }
        bmp.UnlockBits(bmd);
    }
    private Color getPixel(BitmapData bmd, int x, int y)
    {
        Color result;
        unsafe
        {
            byte* pixel1 = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x * 3);
            byte* pixel2 = (byte*)bmd.Scan0 + (y * bmd.Stride) + ((x * 3) + 1);
            byte* pixel3 = (byte*)bmd.Scan0 + (y * bmd.Stride) + ((x * 3) + 2);
            result = Color.FromArgb(*pixel3, *pixel2, *pixel1);
        }
        return result;
    }
