    public static IOrderedQueryable<T> SortThenBy(this IOrderedQueryable<T> orderedQueryable, string field, string direction)
    {
        return direction.ToUpper() == "DESC") 
           ? orderedQueryable.ThenByDescending(field)
           : orderedQueryable.ThenBy(field);
    }
        
