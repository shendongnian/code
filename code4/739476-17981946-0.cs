    public class ResolveParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _param;
        private readonly object _value;
        public ResolveParameterVisitor(ParameterExpression param, object value)
        {
            _param = param;
            _value = value;
        }
        public Expression ResolveLocalValues(Expression exp)
        {
            return Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == _param.Type && node.Name == _param.Name
                && node.Type.IsSimpleType())
            {
                return Expression.Constant(_value);
            }
            
                return base.VisitParameter(node);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var parameters = node.Parameters.Where(p => p.Name != _param.Name && p.Type != _param.Type).ToList();
            return Expression.Lambda(Visit(node.Body), parameters);
        }
    }
