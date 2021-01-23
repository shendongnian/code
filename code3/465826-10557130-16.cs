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
      lock (collection)
      {
        foreach (object item in collection)
        {
          DoSomething(item);
        }
      }
    }
