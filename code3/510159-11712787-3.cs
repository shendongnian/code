    public static IEnumerable<Color> GetPixels(Bitmap bitmap)
    {
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                Color pixel = bitmap.GetPixel(x, y);
                yield return pixel;
            }
        }
    }
