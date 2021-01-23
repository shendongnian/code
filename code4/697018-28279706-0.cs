    static class BitmapExtensions
    {
        public static void RemovePadding(this Bitmap bitmap)
        {
            const int bytesPerPixel = 3;
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var pixels = new byte[bitmapData.Width * bitmapData.Height * bytesPerPixel];
            for (int row = 0; row < bitmapData.Height; row++)
            {
                var dataBeginPointer = IntPtr.Add(bitmapData.Scan0, row * bitmapData.Stride);
                Marshal.Copy(dataBeginPointer, pixels, row * bitmapData.Width * bytesPerPixel, bitmapData.Width * bytesPerPixel);
            }
            Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
            bitmap.UnlockBits(bitmapData);
		}
	}
