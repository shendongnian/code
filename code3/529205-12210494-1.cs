    public static IEnumerable<T> SortBy<T>
    (
        this IEnumerable<T> items,
        string propertyName,
        string sortDirection
    )
    {
        var propInfo = typeof(T).GetProperty(propertyName);
        return items.OrderByDirection(x => propInfo.GetValue(x, null), sortDirection);
    }
    public static IEnumerable<T> OrderByDirection<T,Key>
    (
        this IEnumerable<T> sortable,
        Func<T,Key> keyfn,
        string dir
    )
    {
        if (dir.ToUpper() == "ASC")
            return sortable.OrderBy(keyfn);
        if (dir.ToUpper() == "DESC")
            return sortable.OrderByDescending(keyfn);
    
        throw new ArgumentException("Unknown ordering: " + dir);
    }
