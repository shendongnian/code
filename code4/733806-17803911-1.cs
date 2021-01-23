    public static IList<Tuple<int, int>> RecurringIndexes(Byte[] master, Byte[] toFind, int length) {
      List<Tuple<int, int>> result = new List<Tuple<int, int>>();
      // Let's return empty list ... Or throw appropriate exception
      if (Object.ReferenceEquals(null, master))
        return result;
      else if (Object.ReferenceEquals(null, toFind))
        return result;
      else if (length < 0)
        return result;
      else if (length > toFind.Length)
        return result;
      Byte[] subRegion = new Byte[length];
      for (int i = 0; i <= toFind.Length - length; ++i) {
        for (int j = 0; j < length; ++j)
          subRegion[j] = toFind[j + i];
        for (int j = 0; j < master.Length - length + 1; ++j) {
          Boolean counterExample = false;
          for (int k = 0; k < length; ++k)
            if (master[j + k] != subRegion[k]) {
              counterExample = true;
              break;
            }
          if (counterExample)
            continue;
          result.Add(new Tuple<int, int>(j, j + length - 1));
        }
      }
      return result;
    }
    
    ....
    
    byte[] b = {50,60,70,80,90,10,20,1,2,3,4,5,50,2,3,1,2,3,4,5};
    byte[] b2 = { 1, 2, 3, 4, 5 };
    
    // Returns 2 patterns: {(7, 11), (15, 19)}
    IList<Tuple<int, int>> indice5 = RecurringIndexes(b, b2, 5); 
    // Return 9 patterns: {(7, 8), (15, 16), (8, 9), (13, 14), (16, 17), (9, 10), (17, 18), (10, 11), (18, 19)}
    IList<Tuple<int, int>> indice2 = RecurringIndexes(b, b2, 2);
