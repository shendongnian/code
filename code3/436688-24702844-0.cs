    namespace ConsoleApplication1
    {
        static class Extensions
        {
            public static Expression<Func<T, bool>> ToExpression<T>(this Predicate<T> p)
            {
                ParameterExpression p0 = Expression.Parameter(typeof(T));
                return Expression.Lambda<Func<T, bool>>(Expression.Call(p.Method, p0), 
                      new ParameterExpression[] { p0 });
            }
        }
    }
