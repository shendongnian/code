        public static Bitmap ApplyAlphaMask2(Bitmap source, Bitmap mask)
        {
            int x, y;
            Color mask_color;
            if (source.Size != mask.Size)
            {
                throw new NotImplementedException("Applying a mask of a different size to the source image is not yet implemented");
            }
            Bitmap result = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
            BitmapData source_data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData mask_data = mask.LockBits(new Rectangle(0, 0, mask.Width, mask.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData result_data = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                Int32* source_line_ptr = (Int32*)source_data.Scan0;
                Int32* mask_line_ptr = (Int32*)mask_data.Scan0;
                Int32* result_line_ptr = (Int32*)result_data.Scan0;
                for (y = 0; y < source.Height; y++)
                {
                    for (x = 0; x < source.Width; x++)
                    {
                        mask_color = Color.FromArgb(mask_line_ptr[x]);
                        result_line_ptr[x] = ((int)(mask_color.GetBrightness() * 255.0f) << 24) | (source_line_ptr[x] & 0xFFFFFF);
                    }
                    source_line_ptr += source_data.Stride;
                    mask_line_ptr += mask_data.Stride;
                    result_line_ptr += result_data.Stride;
                }
                source.UnlockBits(source_data);
                mask.UnlockBits(mask_data);
                result.UnlockBits(result_data);
            }
            return result;
        }
