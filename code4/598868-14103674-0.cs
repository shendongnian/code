    [TestMethod]
    public void MyTest()
    {
      AsyncContext.Run(async () =>
      {
        Assert.IsNotNull( SynchronizationContext.Current );
        await MyTestAsync();
        DoSomethingOnTheSameThread();
      });
    }
