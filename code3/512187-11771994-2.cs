    [Test, Property("MajorVersion", "001"), 
     Property("MinorVersion", "B-8345"), Property("Build", "X543")]
    public void TestContextPropertyTest()
    {
        Console.WriteLine(TestContext.CurrentContext.Test.Properties["MajorVersion"]);
        Console.WriteLine(TestContext.CurrentContext.Test.Properties["MinorVersion"]);
        Console.WriteLine(TestContext.CurrentContext.Test.Properties["Build"]);
    }
