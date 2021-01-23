    object lockobj = new object();
    volatile LinkedList<object> collection = new LinkedList<object>();
    
    void Write()
    {
      lock (lockobj)
      {
        var copy = new LinkedList<object>(collection);
        copy.AddLast(GetSomeObject());
        collection = copy;
      }
    }
    
    void Read()
    {
      LinkedList<object> snapshot = collection;
      foreach (object item in snapshot)
      {
        DoSomething(item);
      }
    }
