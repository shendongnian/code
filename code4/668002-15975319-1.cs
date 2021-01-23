    public static void Test(string propertyPath)
    {
        var props = propertyPath.Split('.');
        Expression parameter = Expression.Parameter(typeof(TestObj), "x");
        Expression property = parameter;
        foreach (var propertyName in props)
            property = Expression.Property(property, propertyName);
        Expression<Func<TestObj, int>> lambdaExpression =
            Expression.Lambda<Func<TestObj, int>>(property, parameter as ParameterExpression);
        Add(lambdaExpression);
    }
    static void Add(Expression<Func<TestObj, int>> paramExp)
    {
        TestObj obj = new TestObj { Metadata = new Metadata { RecordId = 1, Name = "test" } };
        var id = paramExp.Compile()(obj);
    }
