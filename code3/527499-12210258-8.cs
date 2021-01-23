    for (int y = 0; y < bmp.Height; y++)
    {
        for (int x = 0; x < bmp.Width; x++)
        {
            Color cA = bmpA.GetPixel(x,y);
            Color cB = bmpB.GetPixel(x,y);
            Color cC = Color.FromArgb(cA.A, cA.R + cB.R, cA.G + cB.G, cA.B + cB.B);
            bmpC.SetPixel(x, y, cC);
        }
    }
