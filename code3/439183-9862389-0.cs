    public static IComparable Max<TResult>(params IComparable[] items)
    {
        IComparable result = items[0];
        foreach (var item in items)
        {
            if (item.CompareTo(result) > 0)
                result = item;
        }
        return result;
    }
