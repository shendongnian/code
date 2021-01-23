    public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string key, bool asc = true)
    {
      try
      {
        string orderMethodName = asc ? "OrderBy" : "OrderByDescending";
        Type type = typeof(T);
        Type propertyType = type.GetProperty(key)?.PropertyType; ;
        var param = Expression.Parameter(type, "x");
        Expression parent = param;
        var keyParts = key.Split('.');
        for (int i = 0; i < keyParts.Length; i++)
        {
          var keyPart = keyParts[i];
          parent = Expression.Property(parent, keyPart);
          if (keyParts.Length > 1)
          {
            if (i == 0)
            {
              propertyType = type.GetProperty(keyPart).PropertyType;
            }
            else
            {
              propertyType = propertyType.GetProperty(keyPart).PropertyType;
            }
          }
        }
        MethodCallExpression orderByExpression = Expression.Call(
          typeof(Queryable),
          orderMethodName,
          new Type[] { type, propertyType },
          query.Expression,
          CreateExpression(type, key)
        );
        return query.Provider.CreateQuery<T>(orderByExpression);
      }
      catch (Exception e)
      {
        return query;
      }
    }
