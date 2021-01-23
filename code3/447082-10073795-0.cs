    public class PaginatedList<T> : List<T>
    {
      public PaginatedList(IEnumerable<T> source, Int32 pageIndex, Int32 pageSize )
      {
        this.AddRange(GetOrderFor<T>().Skip((PageIndex - 1) * PageSize).Take(PageSize));
      }
    }
    
    public static class Helpers
        {
            
            public static Func<T, object> GetSortExpression<T>(string sortExpressionStr)
            {
                var param = Expression.Parameter(typeof (T), "x");
                var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, sortExpressionStr), typeof(object)), param);
                return sortExpression.Compile();
            }
    
            public static IOrderedEnumerable<T> GetOrderFor<T>(this IEnumerable<T> list)
            {
                switch (typeof (T).Name)
                {
                    case "Employee":
                        return list.OrderBy(GetSortExpression<T>("Name")).ThenBy(GetSortExpression<T>("Age"));
                    case "Category":
                        return list.OrderBy(GetSortExpression<T>("Name")).ThenBy(GetSortExpression <T> ("Id"));
                }
                return null;
            }
        }
