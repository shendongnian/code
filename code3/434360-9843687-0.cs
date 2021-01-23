    private static string ConvertToSetCommand<T>(Expression<Func<T, T>> exp)
    {
        if (exp.Body.NodeType != ExpressionType.MemberInit)
        {
            throw new ArgumentException("The expression must have an object initializer.", "exp");
        }
        var builder = new StringBuilder("SET ", 100);
        exp = (Expression<Func<T, T>>) new OmitParametersVisitor().Visit(exp);
        var memberInit = (MemberInitExpression) exp.Body;
        foreach (MemberAssignment assignment in memberInit.Bindings)
        {
            builder.Append(assignment.ToString());
            builder.Append(", ");
        }
        builder.Length -= 2; // Remove the last comma
        return builder.ToString();
    }
    private class OmitParametersVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null && node.Expression.NodeType == ExpressionType.Parameter)
            {
                return Expression.Parameter(node.Type, node.Member.Name);
            }
            else
            {
                return base.VisitMember(node);
            }
        }
    }
