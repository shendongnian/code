    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering)
    {
        var type = typeof(T);
        var property = type.GetProperty(ordering);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda<Func<T, object>>(propertyAccess, parameter);
        IQueryable<T> result = source.OrderBy(orderByExp);
    
        string propertyToRestrictOn = "City";
        string restrictedValue = "Gotham";
        var restrictedProperty = type.GetProperty(propertyToRestrictOn);
        if (restrictedProperty != null)
        {
            var restrictionParameter = Expression.Parameter(type, "p");
            var restrictionPropertyAccess =
                Expression.MakeMemberAccess(restrictionParameter, restrictedProperty);
            var restrictionEquality =
                Expression.Equal(restrictionPropertyAccess,
                                 Expression.Constant(restrictedValue));
            var whereExp =
                Expression.Lambda<Func<T, bool>>(restrictionEquality, parameter);
            result = result.Where(whereExp);
        }
    
       return result;
    }
