    void Write()
    {
      object temp = lockobj; // actually the evaluation of the lock expression
      bool acquired = false;
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
