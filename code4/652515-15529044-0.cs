    public static class ObjectExt
    {
        public static string FindContext<T,TProp>(this T obj, Expression<Func<T,TProp>> expression) {
            return ( expression.Body as MemberExpression ).Member.Name;
        }
    }
