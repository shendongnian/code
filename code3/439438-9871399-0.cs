    Color color = Color.Black; //Your desired colour
     
    byte r = color.R; //For Red colour
     
    Bitmap bmp = new Bitmap(this.BackgroundImage);
    for (int x = 0; x < bmp.Width; x++)
    {
        for (int y = 0; y < bmp.Height; y++)
        {
            Color gotColor = bmp.GetPixel(x, y);
            gotColor = Color.FromArgb(r, gotColor.G, gotColor.B);
            bmp.SetPixel(x, y, gotColor);
        }
    }
