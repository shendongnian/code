    private static Expression<Func<Menu, string>> GetColumnName(string property)
    {
        var menuName = Expression.Parameter(typeof(Menu), "menuName");
        var menuProperty = Expression.PropertyOrField(menuName, property);
        var lambda = Expression.Lambda<Func<Menu, string>>(menuProperty, menuName);
        
        return lambda;
    }
    return list.GroupBy(GetColumnName(columnName).Compile());
