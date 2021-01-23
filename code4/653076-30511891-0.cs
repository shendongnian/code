    private static IList<TestContext> testResults;
    
    public TestContext TestContext
    {
        get
        {
            return testContext;
        }
        set
        {
            testContext = value;
    
            testResults.Add(testContext);
        }
    }
    
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        testResults = new List<TestContext>();
    }
    
    [ClassCleanup()]
    public static void MyClassCleanup()
    {
        if (testResults.All(t => t.CurrentTestOutcome == UnitTestOutcome.Passed ||
            t.CurrentTestOutcome == UnitTestOutcome.Inconclusive))
        {
            // Perform conditional cleanup!
        }
    }
