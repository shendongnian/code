    IEnumerable<T> collectionAsEnumrable = collection;
    foreach(var i in collectionAsEnumrable)
    {
       // something like following can be indirectly called by 
       // synchronous method on the same thread
       collection.Add(i.Clone());
       collection[3] = 33;
    }
