    public static bool In<T>(this T x, params T[] set)
    {
        return set.Contains(x);
    }
    ...
    if (x.In(1, 2, 3)) 
    { ... }
