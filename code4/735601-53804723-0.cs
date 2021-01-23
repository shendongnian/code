    BitmapData d = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
    bmp.UnlockBits(d);
    
    if (d.Stride > 0)
    {
        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
    }
