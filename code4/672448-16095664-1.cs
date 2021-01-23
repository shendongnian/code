    // NEW (start) --------------------------------------------------
    Color[] randomizedColors = new Color[] { Color.Red, Color.Green, Color.Blue };
    Random randomizer = new Random();
    // NEW (end) --------------------------------------------------
    Bitmap img = new Bitmap(InputPictureBox.Image);
    byte R, G, B;
    Color pixelColor;
    // NEW (start) --------------------------------------------------
    Func<int, Color> ColorRandomizer = (numberOfColors) =>
    {
        if (numberOfColors > randomizedColors.Length)
        {
            numberOfColors = randomizedColors.Length;
        }
        return randomizedColors[randomizer.Next(numberOfColors)];
    };
    // NEW (end) --------------------------------------------------
    for (int x = 0; x < img.Width; x++)
    {
        for (int y = 0; y < img.Height; y++)
        {
            pixelColor = img.GetPixel(x, y);
            R = pixelColor.R;
            G = pixelColor.G;
            B = pixelColor.B;
            if (R > G && R > B)
            {
                pixelColor = Color.Red;
            }
            else if (G > R && G > B)
            {
                pixelColor = Color.Green;
            }
            else if (B > R && B > G)
            {
                pixelColor = Color.Blue;
            }
    // NEW (start) --------------------------------------------------
            else if (pixelColor == Color.Yellow)
            {
                // 2 = Red or Green
                pixelColor = ColorRandomizer(2);
            }
            else if (pixelColor = Color.FromArgb(152, 152, 152))
            {
                // 3 = Red, Green, or Blue
                pixelColor = ColorRandomizer(3);
            }
            /* else if (pixelColor = Some_Other_Color)
            {
                // 3 = Red, Green, or Blue
                pixelColor = ColorRandomizer(3);
            } */
    // NEW (end) --------------------------------------------------
            else
            {
                pixelColor = Color.Black;
            }
            img.SetPixel(x, y, pixelColor);
        }
    }
    OutputPictureBox.Image = img;
