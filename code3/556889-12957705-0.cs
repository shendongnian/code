    public static IEnumerable<T> Flatten(
        this IEnumerable<T> source,
        Func<T, IEnumerable<T>> childSelector)
    {
        foreach(T t in source)
        {
            yield return t;
            if (t != null)
            {
                var subList = childSelector(t);
                if (subList != null)
                {
                    foreach(T subT in subList.Flatten(childSelector))
                        yield return subT;
                }
            }
        }
    }
