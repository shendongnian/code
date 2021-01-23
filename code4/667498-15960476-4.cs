    public static string ActionName<T>(Expression<Func<MyClass<T>, Action<T>>> expression)
    {
        return GetMemberName(expression.Body);
    }
    public static string GetMemberName(Expression expression)
    {
        switch (expression.NodeType)
        {
            case ExpressionType.Lambda:
                var lambdaExpression = (LambdaExpression)expression;
                return GetMemberName(lambdaExpression.Body);
            case ExpressionType.MemberAccess:
                var memberExpression = (MemberExpression)expression;
                var supername = GetMemberName(memberExpression.Expression);
                if (String.IsNullOrEmpty(supername))
                    return memberExpression.Member.Name;
                return String.Concat(supername, '.', memberExpression.Member.Name);
            case ExpressionType.Call:
                var callExpression = (MethodCallExpression)expression;
                return callExpression.Method.Name;
            case ExpressionType.Convert:
                var unaryExpression = (UnaryExpression)expression;
                return GetMemberName(unaryExpression.Operand);
            case ExpressionType.Parameter:
                return String.Empty;
            default:
                throw new ArgumentException(
                    "The expression is not a member access or method call expression");
        }
    }
