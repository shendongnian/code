    public enum SortDirection
    {
        Ascending,
        Descending
    }
    
    public static IOrderedEnumerable<T> OrderByPropertyName<T>
    (
        this IEnumerable<T> items,
        string propertyName,
        SortDirection sortDirection = SortDirection.Ascending
    )
    {
        var propInfo = typeof(T).GetProperty(propertyName);
        return items.OrderByDirection(x => propInfo.GetValue(x, null), sortDirection);
    }
    public static IOrderedEnumerable<T> OrderByDirection<T, TKey>
    (
        this IEnumerable<T> items,
        Func<T, TKey> keyExpression,
        SortDirection sortDirection = SortDirection.Ascending
    )
    {
        switch (sortDirection)
        {
            case SortDirection.Ascending:
                return items.OrderBy(keyExpression);
            case SortDirection.Descending:
                return items.OrderByDescending(keyExpression);
        }
        throw new ArgumentException("Unknown SortDirection: " + sortDirection);
    }
