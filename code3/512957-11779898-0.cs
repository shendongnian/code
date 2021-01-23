    public void ApplyInvert()
    {
        byte A, R, G, B;
        Color pixelColor;
    
        for (int y = 0; y < bitmapImage.Height; y++)
        {
            for (int x = 0; x < bitmapImage.Width; x++)
            {
                pixelColor = bitmapImage.GetPixel(x, y);
                A = pixelColor.A;
                R = (byte)(255 - pixelColor.R);
                G = (byte)(255 - pixelColor.G);
                B = (byte)(255 - pixelColor.B);
                bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
            }
        }
    
    }
