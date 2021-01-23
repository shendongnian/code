    private void ProcessUsingLockbits(Bitmap ProcessedBitmap)
    {
        BitmapData bitmapData = ProcessedBitmap.LockBits(new Rectangle(0, 0, ProcessedBitmap.Width, ProcessedBitmap.Height), ImageLockMode.ReadWrite, ProcessedBitmap.PixelFormat);
        int BytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(ProcessedBitmap.PixelFormat) / 8;
        int ByteCount = bitmapData.Stride * ProcessedBitmap.Height;
        byte[] Pixels = new byte[ByteCount];
        IntPtr PtrFirstPixel = bitmapData.Scan0;
        Marshal.Copy(PtrFirstPixel, Pixels, 0, Pixels.Length);
        int HeightInPixels = bitmapData.Height;
        int WidthInBytes = bitmapData.Width * BytesPerPixel;
        for (int y = 0; y < HeightInPixels; y++)
        {
            int CurrentLine = y * bitmapData.Stride;
            for (int x = 0; x < WidthInBytes; x = x + BytesPerPixel)
            {
                int OldBlue = Pixels[CurrentLine + x];
                int OldGreen = Pixels[CurrentLine + x + 1];
                int OldRed = Pixels[CurrentLine + x + 2];
                // Transform blue and clip to 255:
                Pixels[CurrentLine + x] = (byte)((OldBlue + BlueMagnitudeToAdd > 255) ? 255 : OldBlue + BlueMagnitudeToAdd);
                // Transform green and clip to 255:
                Pixels[CurrentLine + x + 1] = (byte)((OldGreen + GreenMagnitudeToAdd > 255) ? 255 : OldGreen + GreenMagnitudeToAdd);
                // Transform red and clip to 255:
                Pixels[CurrentLine + x + 2] = (byte)((OldRed + RedMagnitudeToAdd > 255) ? 255 : OldRed + RedMagnitudeToAdd);
            }
        }
        // Copy modified bytes back:
        Marshal.Copy(Pixels, 0, PtrFirstPixel, Pixels.Length);
        ProcessedBitmap.UnlockBits(bitmapData);
    }
