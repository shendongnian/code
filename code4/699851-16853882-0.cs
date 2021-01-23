    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath2))
    {
       for (int y = 1; y <= ImH; y++)
       {
          for (int x = 1; x <= ImW; x++)
          {
              Color pixelColor = image1.GetPixel(x,y);
              byte r = pixelColor.R;
              byte g = pixelColor.G;
              byte b = pixelColor.B;
              string pixData = String.Format ("({0},{1},{2}", new object[] {r, g, b});
              file.WriteLine(pixData);
           }
        }
    }
