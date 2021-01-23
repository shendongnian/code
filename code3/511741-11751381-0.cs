    public List<String> GetBlackDots()
    {
        Color pixelColor;
        var list = new st<String>();
        for (int y = 0; y < bitmapImage.Height; y++)
        {
            for (int x = 0; x < bitmapImage.Width; x++)
            {
                pixelColor = bitmapImage.GetPixel(x, y);
                if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
                    list.Add(String.Format("x:{0} y:{1}", x, y));
            }
        }
        return list;
    }
