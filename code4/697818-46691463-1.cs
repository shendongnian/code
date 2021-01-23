    [SetUp]
    public void SetUp()
    {
        this.memoryAppender = new MemoryAppender();
        BasicConfigurator.Configure(this.memoryAppender);
    
        ...
    }
    
    [Test]
    public void TestSomething()
    {
        ...
    
        // Assert
        Assert.IsFalse(
            this.memoryAppender.GetEvents().Any(le => le.Level == Level.Error),
            "Did not expect any error messages in the logs");
    }
