    // Writer
    lock (aList)
    {
      aList.Remove(item);
    }
    
    // Reader
    lock (aList)
    {
      foreach (T name in aList)
      {
        name.doSomething();
      }
    }
