    private static Expression<Func<Menu, string>> GetColumnName(string property)
    {
        var menu = Expression.Parameter(typeof(Menu), "menu");
        var menuProperty = Expression.PropertyOrField(menu, property);
        var lambda = Expression.Lambda<Func<Menu, string>>(menuProperty, menu);
        
        return lambda;
    }
    return list.GroupBy(GetColumnName(columnName).Compile());
