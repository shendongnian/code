    m.Order.IfNotNull(s=>s.Substring(0,1),"0") 
    //or
    m.Order.IfNotNull(s=>s.Substring(6,2),"00")
.
    public static class MyExtensions
    {
        public static TOut IfNotNull<T, TOut>(this T target, Func<T, TOut> valueFunc,TOut defValue=default(TOut))
            where T : class
        {
            return target == null ? defValue : valueFunc(target);
        }
    }
