    public static Delegate CreateDelegate( Type delegateType, Action<object[]> target )
    {
        var sourceParameters = delegateType.GetMethod("Invoke").GetParameters();
            
        var parameters = sourceParameters.Select( p => Expression.Parameter( p.ParameterType, p.Name ) ).ToArray();
        var castParameters = parameters.Select(p => Expression.TypeAs(p, typeof(object))).ToArray();
        var createArray = Expression.NewArrayInit(typeof(object), castParameters);
        var invokeTarget = Expression.Invoke(Expression.Constant(target), createArray);
        var lambdaExpression = Expression.Lambda( delegateType, invokeTarget, parameters);
        return lambdaExpression.Compile();
     }
