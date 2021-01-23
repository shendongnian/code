    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> enumerable, string sortColumn, string direction)
    {
         var param = Expression.Parameter(typeof(T), "x");
         var mySortExpression = Expression.Lambda<Func<T, object>>(Expression.Property(param, sortColumn), param);
          IOrderedQueryable<T> iQuery;
          switch(direction)
          {
              case "desc": 
                iQuery = enumerable.OrderByDescending(mySortExpression);
                break;
              case "asc":
              default :
                iQuery = enumerable.OrderBy(mySortExpression);
                break;
          }
          return iQuery;
     }
