    public static Func<TO, TP> BuildSafeAccessor<TO, TP>(Expression<Func<TO, TP>> propertyExpression)
    {
        var properties = GetProperties(propertyExpression.Body);
        var parameter = propertyExpression.Parameters.Single();
        var nullExpression = Expression.Constant(default(TP), typeof(TP));
        var lambdaBody = BuildSafeAccessorExpression(parameter, properties, nullExpression);
        var lambda = Expression.Lambda<Func<TO, TP>>(lambdaBody, parameter);
        return lambda.Compile();
    }
    private static Expression BuildSafeAccessorExpression(Expression init, IEnumerable<PropertyInfo> properties, Expression nullExpression)
    {
        if (!properties.Any())
            return init;
        var propertyAccess = Expression.Property(init, properties.First());
        var nextStep = BuildSafeAccessorExpression(propertyAccess, properties.Skip(1), nullExpression);
        return Expression.Condition(
            Expression.ReferenceEqual(init, Expression.Constant(null)), nullExpression, nextStep);
    }
    private static IEnumerable<PropertyInfo> GetProperties(Expression expression)
    {
        var results = new List<PropertyInfo>();
        while (expression is MemberExpression)
        {
            var memberExpression = (MemberExpression)expression;
            results.Add((PropertyInfo)memberExpression.Member);
            expression = memberExpression.Expression;
        }
        if (!(expression is ParameterExpression))
            throw new ArgumentException();
        results.Reverse();
        return results;
    }
