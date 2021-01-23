    public class UnifyParametersVisitor : ExpressionVisitor
    {
        private IEnumerable<ParameterExpression> parameters;
        public Expression<TDel> UnifyParameters<TDel>(Expression<TDel> expression)
        {
            parameters = expression.Parameters;
            return (Expression<TDel>) Visit(expression);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            foreach (var param in parameters)
            {
                if (param.Name == node.Name)
                {
                    return param;
                }
            }
            return base.VisitParameter(node);
        }
    }
