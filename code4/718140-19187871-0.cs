    static string[] withAddedItem(string[] oldList, string dat)
    {
      string[] result = new string[oldList.Length+1];      
      Array.Copy(oldList, result, oldList.Length);
      return result;
    }
    int Add(string dat) // Returns index of newly-added item
    {
      string[] oldList, newList;
      if (listLock[0] == 0)
      {
        oldList  = list;
        newList = withAddedItem(oldList, dat);
        if (System.Threading.Interlocked.CompareExchange(list, newList, oldList) == oldList)
          return newList.Length;
      }
      System.Threading.Interlocked.Increment(listLock[0]);
      lock (listLock)
      {
        do
        {
          oldList  = list;
          newList = withAddedItem(oldList, dat);
        } while (System.Threading.Interlocked.CompareExchange(list, newList, oldList) != oldList);
      }
      System.Threading.Interlocked.Decrement(listLock[0]);
      return newList.Length;
    }
