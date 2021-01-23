    IEnumerable<Tuple<T,T>> Pairs(IEnumerable<T> items)
    {
        T first;
        bool hasFirst = false;
        foreach(T item in items)
        {
           if (hasFirst)
              yield return Tuple.Create(first, item);
           else
           {
               hasFirst = true;
               first = item;
           }
        }
    }
