    [Test]
    public void DoSomething()
    {
        var sut = new Whatever();
        var dependencyMock = MockRepository.GenerateMock<IDependency>();
        dependencyMock.Stub(() => mock.Method1()).Repeat = 1;
        dependencyMock.Stub(() => mock.Method2()).Repeat = 1;
        sut.DoSomething(dependencyMock);
        // verify that expected methods are being called
        dependencyMock.VerifyAllExpectations(); 
        // make some meaningful assert for sut.
        Assert. // ... etc
    }
