    public unsafe bool[,] ConvertBitmapToBoolArray(Bitmap b, uint threshold) 
    {
      BitmapData originalData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    
      bool[,] ar = new bool[b.Width, b.Height];
    
      for (int y = 0; y < b.Height; y++) 
      {
        byte* Row = (byte*)originalData.Scan0 + (y * originalData.Stride);
        for (int x = 0; x < b.Width; x++) 
        {
          if ((byte)Row[x * 3] < treshold) 
          {
            ar[x, y] = false;
          } else 
          {
            ar[x, y] = true;
          }
        }
      }
      b.Dispose();
      return ar;
    }
