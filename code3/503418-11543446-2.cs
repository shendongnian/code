    public static IEnumerable<T> Recursive<T>(
        this IEnumerable<T> source, 
        Func<T, IEnumerable<T>> recursiveFunc)
    {
        foreach (T item in source)
        {
            yield return item;
            var result = recursiveFunc(item);
            if (result != null)
            {
                foreach (T nextItem in Recursive(result, recursiveFunc))
                {
                    yield return nextItem;
                }
            }
        }
    }
