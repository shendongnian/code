    public static IEnumerable<int>
    GetIndexes(int[] xx, int toSearch )
    {
      // Yield even numbers in the range. 
      for (int i= 0; i < xx.Length; i++)
      {
          if (xx[i] == toSearch)
          {
              yield return xx[i];
          }
      }
    }
