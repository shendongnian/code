    [Test]
    public void WhenViewChangedEventIsRaised_PresenterSetsCopyProperty()
    {
        var viewMock = A.Fake<IView>();
        var presenter = new Presenter(viewMock);
        A.CallTo(() => viewMock.Original).Returns("Testing ...");
        viewMock.Changed += Raise.With(EventArgs.Empty).Now;
        Assert.AreEqual(viewMock.Copy, "Testing ...");
    }
