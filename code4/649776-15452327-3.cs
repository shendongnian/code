    public static IEnumerable<Control> OfType<T1, T2>(this IEnumerable source) where T1 : Control T2 : Control
    {
        foreach (object item in source)
        {
            if (item is T1 || item is T2)
            {
                yield return item;
            }
        }
    }
