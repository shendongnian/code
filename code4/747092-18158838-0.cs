    private static LambdaExpression CreateKeyExpression(Type C1Type, object[] parameters)
    {
        var instanceParameter = Expression.Parameter(C1Type);
        PropertyInfo[] objectKeys = C1Type.GetKeyProperties().ToArray();
    
        var expr = Expression.Equal(Expression.Property(instanceParameter, objectKeys[0]),
            Expression.Constant(parameters[0], objectKeys[0].PropertyType));
                
    
        for (int i = 1; i < objectKeys.Length; i++)
        {
            expr = Expression.AndAlso(expr, Expression.Equal(
                Expression.Property(instanceParameter, objectKeys[i]),
                Expression.Constant(parameters[i], objectKeys[i].PropertyType)));
        }
        return Expression.Lambda(expr, instanceParameter);
    }
    var parameters = new object[] { Guid.NewGuid(), Guid.NewGuid() };
    var lambdaExpression = CreateKeyExpression(typeof(TestClass), parameters);
    var testClasses = new List<TestClass>() { new TestClass { Id = (Guid)parameters[0], Id1 = (Guid)parameters[1] } };
    var testClass = testClasses.AsQueryable().FirstOrDefault((Expression<Func<TestClass, bool>>)lambdaExpression);
