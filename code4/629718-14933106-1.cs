    class Visitor<T> : ExpressionVisitor
    {
        ParameterExpression _parameter;
        public Visitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
                throw new NotImplementedException();
            var memberName = node.Member.Name;
            var otherMember = typeof(T).GetProperty(memberName);
            return Expression.Property(Visit(node.Expression), otherMember);
        }
    }
