    static public Bitmap cropBitmap(Bitmap sourceImage, Rectangle rectangle)
    {
        const int BPP = 4; //4 Bpp = 32 bits; argb
        var sourceBitmapdata = sourceImage.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var croppedImage = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
        var croppedBitmapData = croppedImage.LockBits(new Rectangle(0, 0, rectangle.Width, rectangle.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        unsafe
        {
            byte* sourceImagePointer = (byte*)sourceBitmapdata.Scan0.ToPointer();
            byte* croppedImagePointer = (byte*)croppedBitmapData.Scan0.ToPointer();
            int croppedBitmapStride = Math.Abs(croppedBitmapData.Stride);
            int sourceBitmapStride = Math.Abs(sourceBitmapdata.Stride);
            for (int i = 0; i < rectangle.Width; i++)
            {
                for (int j = 0; j < rectangle.Height; j++)
                {
                    for (int k = 0; k < BPP; k++)
                    {
                        // copy every channel - 0 - b, 1 - g, 2 - r, 3 - a
                        croppedImagePointer[i * BPP + j * croppedBitmapStride + k] =
                            sourceImagePointer[i * BPP + j * sourceBitmapStride + k]; //a
                    }
                }
            }
        }
        sourceImage.UnlockBits(sourceBitmapdata);
        croppedImage.UnlockBits(croppedBitmapData);
        return croppedImage;
    }
