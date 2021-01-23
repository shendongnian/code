    public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string sortProperty, ListSortDirection sortOrder)
        {
            var type = typeof(T);
            var property = type.GetTypeInfo().GetDeclaredProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { type, property.PropertyType };
            var methodName = sortOrder == ListSortDirection.Ascending ? "ThenBy" : "ThenByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
