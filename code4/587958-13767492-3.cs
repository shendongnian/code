    public static int FindIndex<T>(this IList<T> source, int startIndex,
                                   Predicate<T> match)
    {
        // TODO: Validation
        for (int i = startIndex; i < source.Count; i++)
        {
            if (match(source[i]))
            {
                return i;
            }
        }
        return -1;
    }
