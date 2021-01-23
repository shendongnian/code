    [TearDown]
    public void TearDown()
    {
    	if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
    	{
    		Console.WriteLine(TestContext.CurrentContext.Test.FullName);
    		Console.WriteLine(TestContext.CurrentContext.Result.Status);
    	}
    }
