    [Theory, AutoDomainData]
    public void TestWithAutoFixtureDeclaratively(
        string expectedRecord,
        BoundArgumentOption boundArgOption,
        Fake<IRepository> repositoryStub,
        [Frozen]Fake<IRepositoryFactory> repositoryFactoryStub,
        HtmlOutputBuilder sut)
    {
        // Fixture setup
        A.CallTo(() =>
            repositoryStub
                .FakedObject
                .Get(boundArgOption))
                .Returns(expectedRecord);
        A.CallTo(() =>
            repositoryFactoryStub
                .FakedObject
                .Create(boundArgOption))
                .Returns(repositoryStub.FakedObject);
        // Exercise system
        string result = sut.BuildReport(boundArgOption);
        // Verify outcome
        result.Should().Be(expectedRecord);
        // Teardown
    } 
