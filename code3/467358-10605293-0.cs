            Bitmap bm = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bm.LockBits(new Rectangle(0,0,16,16), ImageLockMode.WriteOnly, bm.PixelFormat);
            IntPtr ptr = bitmapData.Scan0;
            byte[] rgbValues = new byte[16 * 16 * 3];
            int b = 0;
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    if (x < 7)
                    {
                        rgbValues[b++] = 255; // BLUE, not red!
                        rgbValues[b++] = 0; // g
                        rgbValues[b++] = 0; // r
                    }
                    else
                    {
                        rgbValues[b++] = 0; // r
                        rgbValues[b++] = 0; // g
                        rgbValues[b++] = 0; // b
                    }
                }
            }
            int bytes = rgbValues.Length;
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bm.UnlockBits(bitmapData);
            pictureBox1.Image = bm;
        }
