    private void Invert(Bitmap bmp)
    {
        int w = bmp.Width, h = bmp.Height;
        BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        
        int* bytes = (int*)data.Scan0;
        for ( int i = w*h-1; i >= 0; i-- )
            bytes[i] = ~bytes[i];
        bmp.UnlockBits(data);
    }
