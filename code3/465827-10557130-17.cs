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
      LinkedList<object> copy;
      lock (collection)
      {
        copy = new LinkedList<object>(collection);
      }
      foreach (object item in copy)
      {
        DoSomething(item);
      }
    }
