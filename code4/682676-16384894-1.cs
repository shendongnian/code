        /// <summary>
        /// Changes the color of every pixel in a WriteableBitmap with an alpha value > 0 to the desired color.
        /// </summary>
        /// <param name="wbmi"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private static WriteableBitmap ColorChange(WriteableBitmap wbmi, System.Windows.Media.Color color)
        {
            for (int pixel = 0; pixel < wbmi.Pixels.Length; pixel++)
            {
                byte[] colorArray = BitConverter.GetBytes(wbmi.Pixels[pixel]);
                byte blue         = colorArray[0];
                byte green        = colorArray[1];
                byte red          = colorArray[2];
                byte alpha        = colorArray[3];
                if (alpha > 0)
                {
                    wbmi.SetPixeli(pixel, alpha, color);
                }
            }
            wbmi.Invalidate();
            return wbmi;
        }
