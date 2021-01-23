        /// <summary>
        /// Split PNG file into two JPGs (RGB and alpha)
        /// </summary>
        private void SplitPngFileIntoRGBandAplha(string imagePath)
        {
            try
            {
                // Open original bitmap
                var bitmap = new Bitmap(imagePath);
                // Rectangle 
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                // Get RGB bitmap
                var bitmapInRgbFormat = bitmap.Clone(rect, PixelFormat.Format32bppRgb);
                // Read bitmap data
                BitmapData bmData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
                // Prepare alpha bitmap
                var alphaBitmap = new Bitmap(bmData.Width, bmData.Height, PixelFormat.Format32bppRgb);
                for (int y = 0; y <= bmData.Height -1; y++)
                {
                    for (int x = 0; x <= bmData.Width -1; x++)
                    {
                        Color PixelColor = Color.FromArgb(Marshal.ReadInt32(bmData.Scan0, (bmData.Stride * y) + (4 * x)));
                        if (PixelColor.A > 0 & PixelColor.A <= 255)
                        {
                            alphaBitmap.SetPixel(x, y, Color.FromArgb(PixelColor.A, PixelColor.A, PixelColor.A, PixelColor.A));
                        }
                        else
                        {
                            alphaBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                        }
                    }
                }
                bitmap.UnlockBits(bmData);
                // Prepare JPG format
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                var encoder =  Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                var encoderParameter = new EncoderParameter(encoder, 100L);
                encoderParameters.Param[0] = encoderParameter;
                // Save RGB bitmap
                bitmapInRgbFormat.Save(imagePath.Replace("png", "jpg"), jgpEncoder, encoderParameters);
                // Save Alpha bitmpa
                alphaBitmap.Save(imagePath.Replace(".png", "_alpha.jpg"), jgpEncoder, encoderParameters);
                bitmap.Dispose();
                bitmapInRgbFormat.Dispose();
                bitmap.Dispose();
                // Delete bitmap
                System.IO.File.Delete(imagePath);
            }
            catch(Exception e)
            {
                 // Handle exception
            }
            
        }
