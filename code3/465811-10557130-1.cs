    LinkedList<object> collection = new LinkedList<object>();
    
    void Write()
    {
      lock (collection)
      {
        collection.AddLast(GetSomeObject());
      }
    }
    
    void Read()
    {
      LinkedList<object> snapshot;
      lock (collection)
      {
        snapshot = new LinkedList<object>(collection);
      }
      foreach (object item in snapshot)
      {
        DoSomething(item);
      }
    }
