    public static U CatchLog<T,U>(this IEnumerable<T> collection, Func<IEnumerable<T>,U> method)
    {
        try
        {
            return method(collection);
        }
        catch(Exception e)
        {
             Debug.WriteLine(e.Message);
             throw;
        }
    }
