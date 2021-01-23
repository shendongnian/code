    [Test]
    public void VerifyAttachesToViewEvents()
    {
        // arrange
        var mock = new Mock<IView>();
        new Presenter(mock.Object);
    
        // act
        Action action = () => mock.Raise(view => view.Load += null, EventArgs.Empty);
    
        // assert
        action.ShouldThrow<Exception>()
            .WithMessage("Not implemented.");
    }
