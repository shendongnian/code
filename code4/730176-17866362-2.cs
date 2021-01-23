    float hue = 0;
    int w = bmp.Width;
    int h = bmp.Height;               
    for (int y = 0; y < bmp.Height; y++) {
      for (int x = 0; x < bmp.Width; x++) {
        Color c = bmp.GetPixel(x, y);
        hue += c.GetHue();
      }
    }
    hue /= (bmp.Width*bmp.Height);
