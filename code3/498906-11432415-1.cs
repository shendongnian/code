    // System.Linq.Enumerable
    private static IEnumerable<TResult> OfType<TResult>(IEnumerable source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
    
        foreach (object current in source)
        {
            // **Type check**
            if (current is TResult)
            {
                // **Explicit cast**
                yield return (TResult)current;
            }
        }
        yield break;
    }
    
    // System.Linq.Enumerable
    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
    {
        IEnumerable<TResult> enumerable = source as IEnumerable<TResult>;
        if (enumerable != null)
        {
            return enumerable;
        }
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
    
        foreach (object current in source)
        {
            // **Explicit cast only**
            yield return (TResult)current;
        }
        yield break;
    }
