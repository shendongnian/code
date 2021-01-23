    Rectangle bounds = new Rectangle(0,0,bitmapA.Width,bitmapA.Height);
    var bmpDataA = bitmapA.LockBits(bounds, ImageLockMode.ReadWrite, bitmapA.PixelFormat);
    var bmpDataB = bitmapB.LockBits(bounds, ImageLockMode.ReadWrite, bitmapB.PixelFormat);
    const int height = 720;
    int npixels = height * bmpDataA.Stride/4;
    unsafe {
        int * pPixelsA = (int*)bmpDataA.Scan0.ToPointer();
        int * pPixelsB = (int*)bmpDataB.Scan0.ToPointer();
    
        for ( int i = 0; i < npixels; ++i ) {
            if (pPixelsA[i] != pPixelsB[i]) {
                 pPixelsB[i] = Color.Black.ToArgb();
            }
        }
    }
    bitmapA.UnlockBits(bmpDataA);
    bitmapB.UnlockBits(bmpDataB);
