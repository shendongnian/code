    /// <summary>
        /// Replaces a given color in a bitmap
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static unsafe void ReplaceColor(Bitmap image,
            Color FindColor,
            int WithinDistance,
            Color ReplaceColor
            )
        {
            byte FindColorR = (byte)FindColor.R;
            byte FindColorG = (byte)FindColor.G;
            byte FindColorB = (byte)FindColor.B;
            byte ReplaceColorR = (byte)ReplaceColor.R;
            byte ReplaceColorG = (byte)ReplaceColor.G;
            byte ReplaceColorB = (byte)ReplaceColor.B;
            byte WithinDistanceByte = (byte)WithinDistance;
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
           
            int bytesPerPixel = 3;
            byte* scan0 = (byte*)imageData.Scan0.ToPointer();
            int stride = imageData.Stride;
            PixelData NewData = new PixelData(image.Height,image.Size);
            for (int y = 0; y < imageData.Height; y++)
            {
                byte* row = scan0 + (y * stride);
                for (int x = 0; x < imageData.Width; x++)
                {
                    int bIndex = x * bytesPerPixel;
                    int gIndex = bIndex + 1;
                    int rIndex = bIndex + 2;
                    byte pixelR = row[rIndex];
                    byte pixelG = row[gIndex];
                    byte pixelB = row[bIndex];
                    
                    if( Math.Abs(FindColorR - pixelR) > WithinDistanceByte && 
                        Math.Abs(FindColorG - pixelG) > WithinDistanceByte &&
                        Math.Abs(FindColorB - pixelB) > WithinDistanceByte )
                    {
                        row[rIndex] = ReplaceColorR;
                        row[gIndex] = ReplaceColorG;
                        row[bIndex] = ReplaceColorB;
                    }
                    else
                    {
                        row[rIndex] = FindColorR;
                        row[gIndex] = FindColorG;
                        row[bIndex] = FindColorB;
                    }
                }
            }
            image.UnlockBits(imageData);
        }
