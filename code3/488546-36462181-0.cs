    public class ExpressionParameterSubstitute : System.Linq.Expressions.ExpressionVisitor
    {
        private readonly ParameterExpression from;
        private readonly Expression to;
        public ExpressionParameterSubstitute(ParameterExpression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (node.Parameters.All(p => p != this.from))
                return node;
            // We need to replace the `from` parameter, but in its place we need the `to` parameter(s)
            // e.g. F<DateTime,Bool> subst F<Source,DateTime> => F<Source,bool>
            // e.g. F<DateTime,Bool> subst F<Source1,Source2,DateTime> => F<Source1,Source2,bool>
            var toLambda = to as LambdaExpression;
            var substituteParameters = toLambda?.Parameters ?? Enumerable.Empty<ParameterExpression>();
            ReadOnlyCollection<ParameterExpression> substitutedParameters
                = new ReadOnlyCollection<ParameterExpression>(node.Parameters
                    .SelectMany(p => p == this.from ? substituteParameters : Enumerable.Repeat(p, 1) )
                    .ToList());
            var updatedBody = this.Visit(node.Body);        // which will convert parameters to 'to'
            return Expression.Lambda(updatedBody, substitutedParameters);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            var toLambda = to as LambdaExpression;
            if (node == from) return toLambda?.Body ?? to;
            return base.VisitParameter(node);
        }
    }
