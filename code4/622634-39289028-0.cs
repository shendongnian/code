    var testMethodsMock = new Mock<IFooBarTestMethods>();
    testMethodsMock
        .Setup(x => x.FooBarProxyFactory())
        .Returns(new Mock<IFooBarProxy>());
    var sut = new FooBar(testMethodsMock.Object.FooBarProxyFactory);
    testMethodsMock.Verify(x => x.FooBarProxyFactory(), Times.Exactly(2));
