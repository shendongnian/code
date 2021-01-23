    public class ReturnTypeVisitor<TSource, TReturnValue> : ExpressionVisitor{
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(TSource), typeof(TReturnValue));
            return Expression.Lambda(delegateType, Visit(node.Body), node.Parameters);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                return Expression.Property(Visit(node.Expression), node.Member.Name);
            }
            return base.VisitMember(node);
        }
    }
