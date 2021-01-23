    class PartialApplier : ExpressionVisitor
    {
        private readonly ConstantExpression value;
        private readonly ParameterExpression replace;
        private PartialApplier(ParameterExpression replace, object value)
        {
            this.replace = replace;
            this.value = Expression.Constant(value, value.GetType());
        }
        public override Expression Visit(Expression node)
        {
            var parameter = node as ParameterExpression;
            if (parameter != null && parameter.Equals(replace))
            {
                return value;
            }
            else return base.Visit(node);
        }
        public static Expression<Func<T2,TResult>> PartialApply<T,T2,TResult>(Expression<Func<T,T2,TResult>> expression, T value)
        {
            var result = new PartialApplier(expression.Parameters.First(), value).Visit(expression.Body);
            return (Expression<Func<T2,TResult>>)Expression.Lambda(result, expression.Parameters.Skip(1));
        }
    }
