    private static bool DoesColValueExist<T>(IQueryable dataToSearchIn, string colName, string colValue)
    {
        int noOfClients = 1;
        Type type = typeof(T);
        if (colValue != "" && colName != "")
        {
            var property = type.GetProperty(colName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            Expression left = property.PropertyType == typeof(string) ? propertyAccess : Expression.Call(propertyAccess, typeof(object).GetMethod("ToString", System.Type.EmptyTypes));
            left = Expression.Call(left, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            Expression right = Expression.Constant(colValue.ToLower(), typeof(string));
            MethodInfo method = typeof(string).GetMethod("Equals", new[] { typeof(string) });
            Expression searchExpression = Expression.Call(left, method, right);
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { type },
                dataToSearchIn.Expression,
                Expression.Lambda<Func<T, bool>>(searchExpression, new ParameterExpression[] { parameter }));
            var searchedData = dataToSearchIn.Provider.CreateQuery(whereCallExpression);
            noOfClients = searchedData.Cast<T>().Count();
            if (noOfClients == 0)
                return false;
            else
                return true;
        }
        return true;
    }
