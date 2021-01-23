    public static IList<int> RecurringIndexes(Byte[] master, Byte[] toFind, int length) {
      List<int> result = new List<int>();
    
      // Let's return empty list when no indice can't be found ... Or throw appropriate exception
      if (Object.ReferenceEquals(null, master))
        return result;
      else if (Object.ReferenceEquals(null, toFind))
        return result;
      else if (length <= 0)
        return result;
      else if (length > toFind.Length)
        return result;
    
      for (int i = 0; i < master.Length - toFind.Length + 1; ++i) {
        Boolean counterExample = false;
    
        for (int j = 0; j < length; ++j)
          if (toFind[j] != master[i + j]) {
            counterExample = true;
    
            break;
          }
    
        if (counterExample)
          continue;
    
        result.Add(i);
      }
    
      return result;
    }
    
    ....
    
    byte[] b = {50,60,70,80,90,10,20,1,2,3,4,5,50,2,3,1,2,3,4,5};
    byte[] b2 = { 1, 2, 3, 4, 5 };
    
    IList<int> indice5 = RecurringIndexes(b, b2, 5); // <- {7, 15}
    IList<int> indice2 = RecurringIndexes(b, b2, 2); // <- {7, 15}, once again
