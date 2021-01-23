    public static bool Any(this IEnumerable enumerable)
    {
        if (enumerable == null)
            throw ArgumentNullException("enumerable");
        ...
    }
