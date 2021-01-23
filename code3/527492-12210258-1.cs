        // Assumes all bitmaps are the same size and same pixel format
        BitmapData bmpDataA = bmpA.LockBits(new Rectangle(0, 0, bmpA.Width, bmpA.Height), ImageLockMode.ReadOnly, bmpA.PixelFormat);
        BitmapData bmpDataB = bmpB.LockBits(new Rectangle(0, 0, bmpA.Width, bmpA.Height), ImageLockMode.ReadOnly, bmpA.PixelFormat);
        BitmapData bmpDataC = bmpC.LockBits(new Rectangle(0, 0, bmpA.Width, bmpA.Height), ImageLockMode.WriteOnly, bmpA.PixelFormat);
        void* pBmpA = bmpDataA.Scan0.ToPointer();
        void* pBmpB = bmpDataB.Scan0.ToPointer();
        void* pBmpC = bmpDataC.Scan0.ToPointer();
        int bytesPerPix = bmpDataA.Stride / bmpA.Width;
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Width; x++, pBmpA += bytesPerPix, pBmpB += bytesPerPix, pBmpC += bytesPerPix)
            {
                *(byte*)(pBmpC) = *(byte*)(pBmpB) + *(byte*)(pBmpB); // R
                *(byte*)(pBmpC + 1) = *(byte*)(pBmpB + 1) + *(byte*)(pBmpB + 1); // G
                *(byte*)(pBmpC + 2) = *(byte*)(pBmpB + 2) + *(byte*)(pBmpB + 2); // B
            }
        }
        bmpA.UnlockBits(bmpDataA);
        bmpB.UnlockBits(bmpDataB);
        bmpC.UnlockBits(bmpDataC);
