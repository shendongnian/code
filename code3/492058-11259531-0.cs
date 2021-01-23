    public static class ObjectQueryExtension
    {
        public static ObjectQuery<T> Include<T>(this ObjectQuery<T> mainQuery, Expression<Func<T, object>> subSelector)
        {
            return mainQuery.Include(FuncToString(subSelector.Body));
        }
        private static string FuncToString(Expression selector)
        {
            switch (selector.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((selector as MemberExpression).Member as Reflection.PropertyInfo).Name;
                case ExpressionType.Call:
                    var method = selector as MethodCallExpression;
                    return FuncToString(method.Arguments[0]) + "." + FuncToString(method.Arguments[1]);
                case ExpressionType.Quote:
                    return FuncToString(((selector as UnaryExpression).Operand as LambdaExpression).Body);
            }
            throw new InvalidOperationException();
        }
        public static K Include<T, K>(this EntityCollection<T> mainQuery, Expression<Func<T, object>> subSelector)
            where T : EntityObject, IEntityWithRelationships
            where K : class
        {
            return null;
        }
        public static K Include<T, K>(this T mainQuery, Expression<Func<T, object>> subSelector)
            where T : EntityObject
            where K : class
        {
            return null;
        }
    }
