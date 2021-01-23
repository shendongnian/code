    public void Go()
    {
      if (pixelChanged != null)  
         GoPixelGo((x,y,z) => { });  
      else
         GoPixelGo((i, y, enabled) => pixelChanged.Invoke(i, y, enabled));
    }
    
    public void GoPixelGo(Action<int, int, bool> action)
    {
      for (int i = 0; i < bitjes.Length; i++)
      {
          BitArray curArray = bitjes[i];
          for (int y = 0; y < curArray.Length; y++)
          {
             curArray[y] = !curArray[y];
             action(i,y, false);
          }
      }
    }
