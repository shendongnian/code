    public static IOrderedQueryable<T> SortBy(this IQueryable<T> queryable, string field, string direction)
    {
        return (direction.ToUpper() == "DESC") 
           ? queryable.OrderByDescending(field)
           : queryable.OrderBy(field);
    }
