    using (Bitmap lower = new Bitmap("lower.png"))
    using (Bitmap upper = new Bitmap("upper.png"))
    using (Bitmap output = new Bitmap(lower.Width, lower.Height))
    {
        int width = lower.Width;
        int height = lower.Height;
        var rect = new Rectangle(0, 0, width, height);
        BitmapData lowerData = lower.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        BitmapData upperData = upper.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        BitmapData outputData = output.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        unsafe
        {
            byte* lowerPointer = (byte*) lowerData.Scan0;
            byte* upperPointer = (byte*) upperData.Scan0;
            byte* outputPointer = (byte*) outputData.Scan0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    HSLColor lowerColor = new HSLColor(lowerPointer[2], lowerPointer[1], lowerPointer[0]);
                    HSLColor upperColor = new HSLColor(upperPointer[2], upperPointer[1], upperPointer[0]);
                    upperColor.Luminosity = lowerColor.Luminosity;
                    Color outputColor = (Color) upperColor;
                    outputPointer[0] = outputColor.B;
                    outputPointer[1] = outputColor.G;
                    outputPointer[2] = outputColor.R;
                    // Moving the pointers by 3 bytes per pixel
                    lowerPointer += 3;
                    upperPointer += 3;
                    outputPointer += 3;
                }
                // Moving the pointers to the next pixel row
                lowerPointer += lowerData.Stride - (width * 3);
                upperPointer += upperData.Stride - (width * 3);
                outputPointer += outputData.Stride - (width * 3);
            }
        }
        lower.UnlockBits(lowerData);
        upper.UnlockBits(upperData);
        output.UnlockBits(outputData);
        // Drawing the output image
    }
