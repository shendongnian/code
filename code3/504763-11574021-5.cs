    public static IOrderedQueryable<T> EuclideanDistanceOrder<T>(this IQueryable<T> query, IEnumerable<Expression<Func<T, double>>> expressions)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        var seed = Expression.Constant((double)0);
        var agg = expressions.Aggregate((Expression)seed, (s, item) => Expression.Add(s, Expression.Power(Replace(item.Body, item.Parameters[0], parameter), Expression.Constant((double)2))));
        return query.OrderBy(Expression.Lambda<Func<T, double>>(agg, parameter));
    }
    private static Expression Replace(Expression expression, ParameterExpression original, ParameterExpression replacement)
    {
        if (expression is BinaryExpression)
        {
            var binaryExpression = (BinaryExpression)expression;
            return Expression.MakeBinary(expression.NodeType, Replace(binaryExpression.Left, original, replacement), Replace(binaryExpression.Right, original, replacement), binaryExpression.IsLiftedToNull, binaryExpression.Method, binaryExpression.Conversion);
        }
        if (expression is ConditionalExpression)
        {
            var conditionalExpression = (ConditionalExpression)expression;
            return Expression.Condition(Replace(conditionalExpression.Test, original, replacement), Replace(conditionalExpression.IfTrue, original, replacement), Replace(conditionalExpression.IfFalse, original, replacement), conditionalExpression.Type);
        }
        if (expression is ConstantExpression)
        {
            return expression;
        }
        if (expression is MemberExpression)
        {
            var memberExpression = (MemberExpression)expression;
            return Expression.MakeMemberAccess(Replace(memberExpression.Expression, original, replacement), memberExpression.Member);
        }
        if (expression is ParameterExpression)
        {
            var parameterExpression = (ParameterExpression)expression;
            return parameterExpression == original ? replacement : parameterExpression;
        }
        if (expression is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)expression;
            return Expression.MakeUnary(unaryExpression.NodeType, Replace(unaryExpression.Operand, original, replacement), unaryExpression.Type, unaryExpression.Method);
        }
        throw new Exception(string.Format("Unsupported expression type: {0}", expression.NodeType));
    }
