    public static Task<IEnumerable<T>> Concat<T>(Task<IEnumerable<T>> first
        , Task<IEnumerable<T>> second)
    {
        return second.ContinueWith(task => first.Result.Concat(task.Result));
    }
    
