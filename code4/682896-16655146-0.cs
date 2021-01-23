    [SetUp]
    public void TestSetUp()
    {
        _transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() {IsolationLevel = IsolationLevel.RepeatableRead, Timeout = TimeSpan.FromSeconds(5)});
    }
    
    [TearDown]
    public void TestTearDown()
    {
        // Roll back any changes made, per test.
        _transactionScope.Dispose();
    }
