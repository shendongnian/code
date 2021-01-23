    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> enumerable, string sortColumn, string direction)
    {
         var param = Expression.Parameter(typeof(T), "x");
         var mySortExpression = Expression.Lambda<Func<T, object>>(Expression.Property(param, sortColumn), param);
          IOrderedQueryable<T> iQuery;
          if (direction == "asc")
          {
             iQuery = enumerable.OrderBy(mySortExpression);
          }
          else
          {
              iQuery = enumerable.OrderByDescending(mySortExpression);
          }
          return iQuery;
     }
