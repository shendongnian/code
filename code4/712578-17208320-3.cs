    static unsafe Bitmap ReplaceColor(Bitmap source,
                                      Color toReplace,
                                      Color replacement)
    {
      const int pixelSize = 4; // 32 bits per pixel
    
      Bitmap target = new Bitmap(
        source.Width,
        source.Height,
        PixelFormat.Format32bppArgb);
    
      BitmapData sourceData = null, targetData = null;
    
      try
      {
        sourceData = source.LockBits(
          new Rectangle(0, 0, source.Width, source.Height),
          ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
        targetData = target.LockBits(
          new Rectangle(0, 0, target.Width, target.Height),
          ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
    
        for (int y = 0; y < source.Height; ++y)
        {
          byte* sourceRow = (byte*)sourceData.Scan0 + (y * sourceData.Stride);
          byte* targetRow = (byte*)targetData.Scan0 + (y * targetData.Stride);
    
          for (int x = 0; x < source.Width; ++x)
          {
            byte b = sourceRow[x * pixelSize + 0];
            byte g = sourceRow[x * pixelSize + 1];
            byte r = sourceRow[x * pixelSize + 2];
            byte a = sourceRow[x * pixelSize + 3];
    
            if (toReplace.R == r && toReplace.G == g && toReplace.B == b)
            {
              r = replacement.R;
              g = replacement.G;
              b = replacement.B;
            }
    
            targetRow[x * pixelSize + 0] = b;
            targetRow[x * pixelSize + 1] = g;
            targetRow[x * pixelSize + 2] = r;
            targetRow[x * pixelSize + 3] = a;
          }
        }
      }
      finally
      {
        if (sourceData != null)
          source.UnlockBits(sourceData);
    
        if (targetData != null)
          target.UnlockBits(targetData);
      }
    
      return target;
    }
