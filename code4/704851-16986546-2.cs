    public class VariableSubstitutionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        private readonly ConstantExpression _constant;
        public VariableSubstitutionVisitor(ParameterExpression parameter, ConstantExpression constant)
        {
            _parameter = parameter;
            _constant = constant;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _parameter)
            {
                return _constant;
            }
            return node;
        }
    }
