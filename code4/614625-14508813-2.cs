    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering)
    {
        var type = typeof(T);
        var property = type.GetProperty(ordering);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        // necessary for value types to work
        var cast = Expression.Convert(propertyAccess, typeof(object));
        var orderByExp = Expression.Lambda<Func<T, object>>(cast, parameter);
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
                Expression.Lambda<Func<T, bool>>(restrictionEquality, restrictionParameter);
            result = result.Where(whereExp);
        }
    
       return result;
    }
