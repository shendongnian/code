    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<GridFilters> gridFilters)
    {
        // foreach filter
            // Get property (propertyInfo)
            // Get Value(s)
            // Apply Filter
            query = query.Where(PropertyLessThanOrEqualString<T, string>(propertyInfo, value1));
        // ...
        return query;
    }
