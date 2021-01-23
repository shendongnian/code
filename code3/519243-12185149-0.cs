    public static Task<Tuple<bool, T>> TryTakeAsync<T>(this BlockingCollection<T> collection, TimeSpan timeout)
    {
      return Task.Factory.StartNew(() => 
      {
        T item = default(T);
        var result = collection.TryTake(out item, timeout);
        return Tuple.Create(result, item);
      });
    }
