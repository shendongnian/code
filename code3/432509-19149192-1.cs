    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    static unsafe extern int memcpy(byte* dest, byte* src, long count);
    static public Bitmap cropBitmap(Bitmap sourceImage, Rectangle rectangle)
    {
        const int BPP = 4; //4 Bpp = 32 bits; argb
        var sourceBitmapdata = sourceImage.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var croppedImage = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
        var croppedBitmapData = croppedImage.LockBits(new Rectangle(0, 0, rectangle.Width, rectangle.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        unsafe
        {
            croppedBitmapData.Stride = sourceBitmapdata.Stride;
            byte* sourceImagePointer = (byte*)sourceBitmapdata.Scan0.ToPointer();
            byte* croppedImagePointer = (byte*)croppedBitmapData.Scan0.ToPointer();
            memcpy(croppedImagePointer, sourceImagePointer,
                   Math.Abs(croppedBitmapData.Stride) * rectangle.Height);
        }
        sourceImage.UnlockBits(sourceBitmapdata);
        croppedImage.UnlockBits(croppedBitmapData);
        return croppedImage;
    }
