    static Object exclusiveDbAccess = new Object();
    //Use TestInitialize to run code before running each test
    [TestInitialize()]
    public void MyTestInitialize()
    {
        Monitor.Enter(exclusiveDbAccess);
    }
    //
    //Use TestCleanup to run code after each test has run
    [TestCleanup()]
    public void MyTestCleanup()
    {
        Monitor.Exit(exclusiveDbAccess);
    }
	
