    public static IOrderedEnumerable<T> SortBy<T>
    (
        this IEnumerable<T> items,
        string propertyName,
        string sortDirection
    )
    {
        var propInfo = typeof(T).GetProperty(propertyName);
        return items.OrderByDirection(x => propInfo.GetValue(x, null), sortDirection);
    }
    public static IOrderedEnumerable<T> OrderByDirection<T,TKey>
    (
        this IEnumerable<T> sortable,
        Func<T,TKey> keyfn,
        string dir
    )
    {
        switch (dir.ToUpper())
        {
            case "ASC":
                return sortable.OrderBy(keyfn);
            case "DESC":
                return sortable.OrderByDescending(keyfn);
        }
        throw new ArgumentException("Unknown ordering: " + dir);
    }
