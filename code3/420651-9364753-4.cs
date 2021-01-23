    [Test]
    public void VerifyAttachesToViewEvents()
    {
        // arrange
        var mock = new Mock<IView>();
        new Presenter(mock.Object);
    
        // act & assert
        Assert.Throws<Exception>(() => 
             mock.Raise(view => view.Load += null, EventArgs.Empty));
    }
