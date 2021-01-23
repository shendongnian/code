                Bitmap image = new Bitmap("somebitmap.png");
                Rectangle area = new Rectangle(0,0,image.Width, image.Height);
                BitmapData bitmapData = image.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                IntPtr ptr = bitmapData.Scan0;
                int numBytes = bitmapData.Stride * image.Height;
                byte[] rgbValues = new byte[numBytes];
                Marshal.Copy(ptr, rgbValues, 0, numBytes);
