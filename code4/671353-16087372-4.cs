    [TestMethod]
    [DeploymentItem("UnitTests.dll")]
    public void TestMethod1()
    {
        RunTestInCustomDomain("actual_TestMethod1");
    }
    public void actual_TestMethod1()
    {
        // Assert Stuff
    }
