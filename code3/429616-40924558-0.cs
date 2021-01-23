    public class QueryVisitor: ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic && node.Method.Name == "IsNullOrWhiteSpace" && node.Method.DeclaringType.IsAssignableFrom(typeof(string)))
            {
                //!(b.Diameter == null || b.Diameter.Trim() == string.Empty)
                var arg = node.Arguments[0];
                var argTrim = Expression.Call(arg, typeof (string).GetMethod("Trim", Type.EmptyTypes));
                var exp = Expression.MakeBinary(ExpressionType.Or,
                        Expression.MakeBinary(ExpressionType.Equal, arg, Expression.Constant(null, arg.Type)),
                        Expression.MakeBinary(ExpressionType.Equal, argTrim, Expression.Constant(string.Empty, arg.Type))
                    );
            
                return exp;
            }
            return base.VisitMethodCall(node);
        }
    }
    public static class EfQueryableExtensions
    {
        public static IQueryable<T> WhereEx<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> where)
        {
            var visitor = new QueryVisitor();
            return queryable.Where(visitor.VisitAndConvert(where, "WhereEx"));
        }
    }
