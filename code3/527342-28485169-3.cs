        private void bitmap_to_matrix()
        {
            unsafe
            {
                bitmapData = ProcessedBitmap.LockBits(new Rectangle(0, 0, ProcessedBitmap.Width, ProcessedBitmap.Height), ImageLockMode.ReadWrite, ProcessedBitmap.PixelFormat);
                int BytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(ProcessedBitmap.PixelFormat) / 8;
                int HeightInPixels = ProcessedBitmap.Height;
                int WidthInPixels = ProcessedBitmap.Width;
                int WidthInBytes = ProcessedBitmap.Width * BytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, HeightInPixels, y =>
                {
                    byte* CurrentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
                    {
                        // Conversion in grey level                       
                        double rst = CurrentLine[x] * 0.0721 + CurrentLine[x + 1] * 0.7154 + CurrentLine[x + 2] * 0.2125;
                        // Fill the grey matix
                        TG[x / 3, y] = (int)rst;
                    }
                });               
            }
        }
