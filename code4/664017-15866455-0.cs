    HashSet<T> itemsToKeep = new HashSet<T>();
    HashSet<T> itemsToRemove = new HashSet<T>();
    foreach(T item in items)
    {
       if (itemsToRemove.Add(item))
       {
           continue;
       }
       itemsToKeep.Add(item);
    }
    itemsToKeep.ExceptWith(itemsToRemove);
