    public static class DbSetExtensions
    {
        public static IQueryable<T> FindTheLast<T,TResult>(this IQueryable<T> t, Expression<Func<T, TResult>> expression, int nums) where T : class 
        {
          return t.OrderByDescending(expression).Take(nums);
        }
    }  
