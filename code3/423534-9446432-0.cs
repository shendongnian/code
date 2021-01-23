    m.Order.IfNotNull(s=>s.Substring(0,1))
.
    public static class MyExtensions
    {
        public static TOut IfNotNull<T, TOut>(this T target, Func<T, TOut> valueFunc) 
             where T : class
        {
            return target == null ? default(TOut) : valueFunc(target);
        }
    }
