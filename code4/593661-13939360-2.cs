    [Test]
    public void TestSomeCommHandlerEvent()
    {
         var mockCommHandler = new Mock<ICommHandler>();
         // set up the mock
         var core = new Core(mockCommHandler.Object);
    }
