    class TypeConversionVisitor : ExpressionVisitor
    {
        private readonly Dictionary<Expression, Expression> parameterMap;
        public TypeConversionVisitor(
            Dictionary<Expression, Expression> parameterMap)
        {
            this.parameterMap = parameterMap;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            // re-map the parameter
            Expression found;
            if(!parameterMap.TryGetValue(node, out found))
                found = base.VisitParameter(node);
            return found;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            // re-perform any member-binding
            var expr = Visit(node.Expression);
            if (expr.Type != node.Type)
            {
                MemberInfo newMember = expr.Type.GetMember(node.Member.Name)
                                           .Single();
                return Expression.MakeMemberAccess(expr, newMember);
            }
            return base.VisitMember(node);
        }
    }
