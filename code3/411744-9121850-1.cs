    [Test]
    public void TestSomeMethodCalledForEachBar()
    {
        // Setup
        var barMocks = new Mock<IBar>[] { new Mock<IBar>(), new Mock<IBar>() };
        var barObjects = barMocks.Select(m => m.Object);
        var repoList = new List<IBar>(barsObjects);
        var repositoryMock = new Mock<IBarRepository>();
        repositoryMock.Setup(r => r.GetBarsFromStore()).Returns(repoList);
		
        // Execute
        var service = new FooService(repositoryMock.Object);
        service.GetBars();
		
        // Assert
        foreach(var barMock in barMocks)
            barMock.Verify(b => b.SomeMethod("someValue"));
    }
