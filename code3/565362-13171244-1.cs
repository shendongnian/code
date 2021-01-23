    var fixture = new Fixture().Customize(new AutoMoqCustomization());
    var uowProviderStub = fixture.Freeze<Mock<IUnitOfWorkProvider>>();
    var uowMock = fixture.CreateAnonymous<Mock<IUnitOfWork>>();
    var sut = fixture.CreateAnonymous<MyService>();
    uowProviderStub.Setup(p => p.GetUnitOfWork()).Returns(uowMock.Object);
    uowMock
        .Setup(x => x.Db.Insert(It.IsAny<MyDomainObject>()))
        .Verifiable();
    // etc.
