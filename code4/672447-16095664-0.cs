    Bitmap img = new Bitmap(InputPictureBox.Image);
    byte R, G, B;
    Color pixelColor;
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
            else
            {
                pixelColor = Color.Black;
            }
            img.SetPixel(x, y, pixelColor);
        }
    }
    OutputPictureBox.Image = img;
