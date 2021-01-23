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
      LinkedList<object> local = collection;
      foreach (object item in local)
      {
        DoSomething(item);
      }
    }
