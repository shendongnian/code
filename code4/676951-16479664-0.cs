    CoreExtensions.Host.InitializeService();
    TestSuiteBuilder builder = new TestSuiteBuilder();
    TestPackage testPackage = new TestPackage(@"path.to.dll");
    RemoteTestRunner remoteTestRunner = new RemoteTestRunner();
    remoteTestRunner.Load(testPackage);
    TestSuite suite = builder.Build(testPackage);
    TestSuite test = suite.Tests[0] as TestSuite;
    var numberOfTests = ((TestFixture)test.Tests[0]).TestCount;
    
    foreach (TestMethod t in ((TestFixture)test.Tests[0]).Tests)
    {
    	Console.WriteLine(t.TestName.Name);
    }
    
    TestName testName = ((TestMethod)((TestFixture)test.Tests[0]).Tests[0]).TestName;
    TestFilter filter = new NameFilter(testName);
    TestResult result = test.Run(new NullListener(), filter);
    ResultSummarizer summ = new ResultSummarizer(result);
    Assert.AreEqual(1, summ.ResultCount);
