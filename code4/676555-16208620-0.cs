    static LambdaExpression CreateExpression(Type type, string propertyName) {
        var param = Expression.Parameter(type, "x");
        Expression body = param;
        foreach (var member in propertyName.Split('.')) {
            body = Expression.PropertyOrField(body, member);
        }
        return Expression.Lambda(body, param);
    }
