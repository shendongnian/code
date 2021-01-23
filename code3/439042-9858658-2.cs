        private void ReplaceColor(Bitmap bitmap, Color originalColor, Color replacementColor)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == originalColor.ToArgb())
                    {
                        bitmap.SetPixel(x, y, replacementColor);
                    }
                }
            }
        }
        private unsafe void ReplaceColorUnsafe(Bitmap bitmap, byte[] originalColor, byte[] replacementColor)
        {
            if (originalColor.Length != replacementColor.Length)
            {
                throw new ArgumentException("Original and Replacement arguments are in different pixel formats.");
            }
            if (originalColor.SequenceEqual(replacementColor))
            {
                return;
            }
            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size),
                                       ImageLockMode.ReadWrite,
                                       bitmap.PixelFormat);
            var bpp = Image.GetPixelFormatSize(data.PixelFormat);
            if (originalColor.Length != bpp)
            {
                throw new ArgumentException("Original and Replacement arguments and the bitmap are in different pixel format.");
            }
            var start = (byte*)data.Scan0;
            var end = start + data.Stride;
            for (var px = start; px < end; px += bpp)
            {
                var match = true;
                for (var bit = 0; bit < bpp; bit++)
                {
                    if (px[bit] != originalColor[bit])
                    {
                        match = false;
                        break;
                    }
                }
                if (!match)
                {
                    continue;
                }
                
                for (var bit = 0; bit < bpp; bit++)
                {
                    px[bit] = replacementColor[bit];
                }
            }
            bitmap.UnlockBits(data);
        }
