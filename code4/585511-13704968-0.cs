        public static bool HasColor(this Bitmap img, Color color)
        {
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    if (img.GetPixel(x, y) == color)
                        return true;
                }
            }
            return false;
        }
