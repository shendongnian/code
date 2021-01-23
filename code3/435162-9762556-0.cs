    static void Transfer(object source, object target)
    {
        var sourceType = source.GetType();
        var targetType = target.GetType();
        var sourceParameter = Expression.Parameter(typeof(object), "source");
        var targetParameter = Expression.Parameter(typeof(object), "target");
        var sourceVariable = Expression.Variable(sourceType, "castedSource");
        var targetVariable = Expression.Variable(targetType, "castedTarget");
        var expressions = new List<Expression>();
        expressions.Add(Expression.Assign(sourceVariable, Expression.Convert(sourceParameter, sourceType)));
        expressions.Add(Expression.Assign(targetVariable, Expression.Convert(targetParameter, targetType)));
        foreach (var property in sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!property.CanRead)
                continue;
            var targetProperty = targetType.GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
            if (targetProperty != null
                    && targetProperty.CanWrite
                    && targetProperty.PropertyType.IsAssignableFrom(property.PropertyType))
            {
                expressions.Add(
                    Expression.Assign(
                        Expression.Property(targetVariable, targetProperty),
                        Expression.Convert(
                            Expression.Property(sourceVariable, property), targetProperty.PropertyType)));
            }
        }
        var lambda =
            Expression.Lambda<Action<object, object>>(
                Expression.Block(new[] { sourceVariable, targetVariable }, expressions),
                new[] { sourceParameter, targetParameter });
        var del = lambda.Compile();
        del(source, target);
    }
