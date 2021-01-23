    [TestMethod]
    public void here_is_my_test()
    {
        IEnumerable<MyEntityType> fakeResults = GetFakeResults();
    
        using (ShimsContext.Create())
        {
            InterceptCloudTableQueryExecute<MyEntityType>(fakeResults);
    
            DoQuery();
    
            AssertStuff();
        }
    }
    
    public void InterceptCloudTableQueryExecute<T>(IEnumerable<T> result)
    {
        var query = result.AsQueryable();
    
        ShimCloudTableQuery<T>.AllInstances.Execute = (instance) =>
        {
            // Get the expression evaluator.
            MethodCallExpression ex = (MethodCallExpression)instance.Expression;
    
            // Depending on how I called CreateQuery, sometimes the objects
            // I need are nested one level deep.
            if (ex.Arguments[0] is MethodCallExpression)
            {
                ex = (MethodCallExpression)ex.Arguments[0];
            }
    
            UnaryExpression ue = ex.Arguments[1] as UnaryExpression;
    
            // Get the lambda expression
            Expression<Func<T, bool>> le = ue.Operand as Expression<Func<T, bool>>;
    
            query = query.Where(le);
            return query;
        };
    }
