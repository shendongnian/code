    public Point? GetFirstPixel(Bitmap bitmap, Color color)
    {
        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                if (bitmap.GetPixel(x, y).Equals(color))
                {
                    return new Point(x, y);
                }
            }
        }
        return null;
    }
