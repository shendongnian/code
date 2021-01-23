    public static IEnumerable<T> EndQuery<T>(this DataContext ctx,
      IAsyncResult result,
      Func<IDataRecord, T> selector)
    {
      AsyncResult localResult = (AsyncResult)result;
      if (localResult.Exception != null)
      {
        throw localResult.Exception;
      }
      IEnumerable<T> results =
        (localResult.Reader.Cast<IDataRecord>()).Select(selector);
      return (results);
    }
 
