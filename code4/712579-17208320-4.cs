    static Bitmap ReplaceColor(Bitmap source,
                               Color toReplace,
                               Color replacement)
    {
        var target = new Bitmap(source.Width, source.Height);
        for (int x = 0; x < source.Width; ++x)
        {
            for (int y = 0; y < source.Height; ++y)
            {
                var color = source.GetPixel(x, y);
                target.SetPixel(x, y, color == toReplace ? replacement : color);
            }
        }
        return target;
    }
