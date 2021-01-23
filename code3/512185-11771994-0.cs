    [Test, Property("TestCaseVersion", "001, B-8345, X543")]
    public void TestContextPropertyTest()
    {
        Console.WriteLine(TestContext.CurrentContext.Test.Properties["TestCaseVersion"]);
    }
