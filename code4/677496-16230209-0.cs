    public static bool CompareCount(int? currentCount)
    {
        int foundCount = ReadFoundCountFromProperties;
        if (foundCount != 0)
        {
          Properties.Settings.Default.Count = (int)currentCount;
          Properties.Settings.Default.Save();
          if (currentCount < foundCount)
           return false;
        
          return true;
    }   
    
