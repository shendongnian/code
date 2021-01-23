    public static IEnumerable<int> getPyramid(int maxValue)
    {
      for(int i = 0; i < maxValue; i++)
      {
        yield return i;
      }
    
      for(int i = maxValue; i >=0; i--)
      {
        yield return i;
      }
    }
