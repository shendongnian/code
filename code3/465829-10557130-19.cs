    void Write()
    {
      bool acquired = false;
      object temp = lockobj;
      try
      {
        Monitor.Enter(temp, ref acquired);
        var copy = new LinkedList<object>(collection);
        copy.AddLast(GetSomeObject());
        collection = copy;
      }
      finally
      {
        if (acquired) Monitor.Exit(temp);
      }
    }
