    public class ParameterAssignAndReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _source;
        private readonly ConstantExpression _target;
        internal ParameterAssignAndReplacer(ParameterExpression source, ConstantExpression target)
        {
            _source = source;
            _target = target;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node.Name == _source.Name ?
                base.VisitConstant(_target) :
                base.VisitParameter(node);
        }
    }
