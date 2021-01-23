    List<T> collection;
    
    for(int index = collection; index >= 0; --index)
    {
      var item = collection[index];
      
      if(MUST BE DELETED)
      {
        collection.RemoveAt(index); // this is faster
        OR
        collection.Remove(item);
      }
    }
