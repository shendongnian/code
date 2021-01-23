    void Write()
    {
      bool acquired = false;
      try
      {
        object temp = lockobj; // actually the evaluation of the lock expression
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
