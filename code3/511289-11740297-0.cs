        public Bitmap CreateBitmapFromRawDataBuffer(int width, int height, PixelFormat imagePixelFormat, byte[] buffer)
        {
            Size imageSize = new Size(width, height);
            Bitmap bitmap = new Bitmap(imageSize.Width, imageSize.Height, imagePixelFormat);
            Rectangle wholeBitmap = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            // Lock all bitmap's pixels.
            BitmapData bitmapData = bitmap.LockBits(wholeBitmap, ImageLockMode.WriteOnly, imagePixelFormat);
            // Copy the buffer into bitmapData.
            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bitmapData.Scan0, buffer.Length);
            // Unlock  all bitmap's pixels.
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
