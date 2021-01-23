    public static int Count(IEnumerable sequence)
    {
        // Shortcut for any ICollection implementation
        var collection = sequence as ICollection;
        if (collection != null)
        {
            return collection.Count;
        }
        var iterator = sequence.GetEnumerator();
        try
        {
            int count = 0;
            while (iterator.MoveNext())
            {
                count++;
            }
            return count;
        }
        finally
        {
            IDisposable disposable = iterator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
