    public static void TestThat(Expression<Func<TestResult>> action)
    {
        var attrs = ((MethodCallExpression)action.Body).Method.GetCustomAttributes(true);
        var result = action.Compile()();
    }
