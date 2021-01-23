            Bitmap b = new Bitmap(img1);
            BitmapData bitmapData = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb
            );
            int numPixels = b.Width * b.Height;
            byte[] pixels = new byte[numPixels * 3]; // 3 bytes per pixel
            Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);
            // Use this method to apply an effect to each pixel individually
            for (int i = 0; i < pixels.Length; i++)
            {
                byte value = pixels[i];
                // modify value
                pixels[i] = value;
            }
            // Use this method to apply an effect that considers RGB relationship
            byte red, green, blue;
            for (int i = 0; i < pixels.Length; i += 3)
            {
                blue = pixels[i];
                green = pixels[i + 1];
                red = pixels[i + 2];
                // modify values
                pixels[i] = blue;
                pixels[i + 1] = green;
                pixels[i + 2] = red;
            }
            
            Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
            b.UnlockBits(bitmapData);
