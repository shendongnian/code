    [TestMethod]
    public void RunATest()
    {
        // Assert.
        var sut = new MyClass();
        // Act.
        sut.DoSomethingAsync().Wait();
        // Assert.
        Assert.IsTrue(sut.SomethingHappened);
    }
