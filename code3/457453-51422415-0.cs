        private bool isGrayScale(Bitmap processedBitmap)
        { 
            bool res = true;
            unsafe
            {
                System.Drawing.Imaging.BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int b = currentLine[x];
                        int g = currentLine[x + 1];
                        int r = currentLine[x + 2];
                        if (b != g || r != g)
                        {
                            res = false;
                            break;
                        }
                    }
                });
                processedBitmap.UnlockBits(bitmapData);
            }
            return res;
        }
