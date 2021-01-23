    public static TResult Lift<T, TResult>(this T target, Expression<Func<T, TResult>> exp)
        where TResult : class
    {
        return (TResult) GetValueOfExpression(target, exp.Body);
    }
    private static object GetValueOfExpression<T>(T target, Expression exp)
    {
        if (exp.NodeType == ExpressionType.Parameter)
        {
            return target;
        }
        else if (exp.NodeType == ExpressionType.MemberAccess)
        {
            var memberExpression = (MemberExpression) exp;
            var parentValue = GetValueOfExpression(target, memberExpression.Expression);
            if (parentValue == null)
            {
                return null;
            }
            else
            {
                if (memberExpression.Member is PropertyInfo)
                    return ((PropertyInfo) memberExpression.Member).GetValue(parentValue, null);
                else
                    return ((FieldInfo) memberExpression.Member).GetValue(parentValue);
            }
        }
        else
        {
            throw new ArgumentException("The expression must contain only member access calls.", "exp");
        }
    }
