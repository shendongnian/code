    private static Expression BuildDynamicExpression<T>(T arg, MethodInfo method)
    {
        ParameterExpression param = Expression.Parameter(typeof(T));
        return Expression.Lambda(Expression.Call(param, method),
                                 new ParameterExpression[] { param });
    }
