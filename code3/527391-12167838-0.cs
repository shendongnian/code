    Expression<Func<ITest, Func<ServiceRequest, ServiceResponse>>> expression = 
        scv => new Func<ServiceRequest, ServiceResponse>(scv.Get);
    UnaryExpression unaryExpression = expression.Body as UnaryExpression;
    MethodCallExpression methodCallExpression = 
        unaryExpression.Operand as MethodCallExpression;
    ConstantExpression constantExpression = 
        methodCallExpression.Object as ConstantExpression;
    MethodInfo methodInfo;
    if (constantExpression != null)
    {
        methodInfo = constantExpression.Value as MethodInfo;
    }
    else
    {
        constantExpression = methodCallExpression.Arguments
                                .Single(a => a.Type == typeof(MethodInfo) 
                                    && a.NodeType == ExpressionType.Constant) as
                                ConstantExpression;
        methodInfo = constantExpression.Value as MethodInfo;
    }
