    class MyExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression TargetParameterExpression { get; private set; }
        public object TargetParameterValue { get; private set; }
        public MyExpressionVisitor(ParameterExpression targetParameterExpression, object targetParameterValue)
        {
            this.TargetParameterExpression = targetParameterExpression;
            this.TargetParameterValue = targetParameterValue;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == TargetParameterExpression)
                return Expression.Constant(TargetParameterValue);
            return base.VisitParameter(node);
        }
    }
    static class Helper
    {
        public static Expression<Func<B>> BindInput(Expression<Func<A, B>> expression, A input)
        {
            var parameter = expression.Parameters.Single();
            var visitor = new MyExpressionVisitor(parameter, input);
            return Expression.Lambda<Func<B>>(visitor.Visit(expression.Body));
        }
    }
