        public LockedFastImage(Bitmap image)
        {
            this.image = image;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ptr = bmpData.Scan0;
            bytes = Math.Abs(bmpData.Stride) * image.Height;
            rgbValues = new byte[bytes];
            if (bmpData.Stride < 0)
            {
                int lines, pos, BytesPerLine = Math.Abs(bmpData.Stride);
                for (lines = pos = 0; lines < image.Height; lines++, pos += BytesPerLine)
                {
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, pos, BytesPerLine);
                    ptr = (IntPtr)(ptr.ToInt64() + bmpData.Stride);
                }
            }
            else
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
        }
