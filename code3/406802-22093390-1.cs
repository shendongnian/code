    [TestMethod]
    public void Test()
    {
        TestContext.BeginTimer("mytimer");
        httpClient.SendRequest();
        TestContext.EndTimer("mytimer");
    }
        
