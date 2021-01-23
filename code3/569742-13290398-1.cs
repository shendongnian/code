    public static IQueryable<T> Search<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> predicates = null)
            where T : EntityObject
        {
            if (predicates == null || !predicates.Any())
                return source;
            else
            {
                 ParameterExpression p = Expression.Parameter(typeof(T), "p");
                 Expression<Func<T,Bool>> predicate = 
                            Expression.Lambda<Func<T,Bool>(
                                       predicates.Select(l => ReParameteriser(l.Body, l.Paramaters[0], p)
                                                 .Aggregate((b1,b2) => Expression.Or(b1,b2)),
                                       new ParamaterExpression[]{p});
                return source.Where(predicate);
            }
       }
    public class ReParameteriser : ExpressionVisitor
    {
        ParameterExpression originalParameter; 
        ParameterExpression newParameter;
        private ReParameteriser(){}
        protected ReParameteriser (ParameterExpression originalParameter, ParameterExpression newParameter) 
        {
             this.originalParameter = originalParameter;
             this.new = newParameter;
        }
        public static Expression ReParameterise(Expression expression, ParameterExpression originalParameter, ParameterExpression newParameter)
        {
            return new ReParameteriser(original,newParameter).Visit(expression);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == originalParameter)
                return newParameter;
            else
                return node;
        }
    }
