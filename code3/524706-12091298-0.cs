    BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
    int* bitmapPtr = (int*)bitmapData.Scan0.ToPointer();
    for (int pixelCount = 0; pixelCount <= image.Width * image.Height; pixelCount++)
    {
        bitmapPtr[pixelCount] = ...;
        // etc
    }
    image.UnlockBits(bitmapData);
