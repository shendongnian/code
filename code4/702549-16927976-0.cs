    [TestMethod]
    public void AddingNewRequestSetsStatusToSubmitted()
    {
        //Arrange
        var mock = new Mock<IDRepository>(MockBehavior.Strict);
        var mockRequest = new Mock<Request>(MockBehavior.Strict);
        var dManager = new DManager(mock.Object);
        //setup for getting property
        //Act
        dManager.Create(mockRequest.Object);
        //Assert
        Assert.AreEqual(mockRequest.Object.Status, Status.Submitted);
        mock.VerifyAll();
        mockRequest.VerifyAll();
    }
