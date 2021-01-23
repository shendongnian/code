    [SetUp]
    public void SetUp()
    {
        transaction = new TransactionScope();
    }
    [TearDown]
    public void TearDown()
    {
        if(transaction != null) transaction.Dispose();
    }
