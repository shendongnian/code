    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    private unsafe static extern int memcpy(byte* dest, byte* src, long count);
    private unsafe Bitmap Crop(Bitmap srcImg, Rectangle rectangle)
    {
        if ((srcImg.Width == rectangle.Width) && (srcImg.Height == rectangle.Height))
            return srcImg;
        var srcImgBitmapData = srcImg.LockBits(new Rectangle(0, 0, srcImg.Width, srcImg.Height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
        var bpp = srcImgBitmapData.Stride / srcImgBitmapData.Width; // 3 or 4
        var srcPtr = (byte*)srcImgBitmapData.Scan0.ToPointer() + rectangle.Y * srcImgBitmapData.Stride + rectangle.X * bpp;
        var srcStride = srcImgBitmapData.Stride;
        var dstImg = new Bitmap(rectangle.Width, rectangle.Height, srcImg.PixelFormat);
        var dstImgBitmapData = dstImg.LockBits(new Rectangle(0, 0, dstImg.Width, dstImg.Height), ImageLockMode.WriteOnly, dstImg.PixelFormat);
        var dstPtr = (byte*)dstImgBitmapData.Scan0.ToPointer();
        var dstStride = dstImgBitmapData.Stride;
        for (int y = 0; y < rectangle.Height; y++)
        {
            memcpy(dstPtr, srcPtr, dstStride);
            srcPtr += srcStride;
            dstPtr += dstStride;
        }
        srcImg.UnlockBits(srcImgBitmapData);
        dstImg.UnlockBits(dstImgBitmapData);
        return dstImg;
    }
