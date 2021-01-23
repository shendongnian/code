    static void LogSomething(Expression<Action> expression)
    {
        var methodCallExpression = ((MethodCallExpression) expression.Body);
        var parameterNames = methodCallExpression.Method.GetParameters().Select(p => p.Name);
        var values = methodCallExpression.Arguments.Select(a => a.Value);
    }
