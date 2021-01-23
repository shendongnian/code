    [Fact]
    public void TestWithAutoFixtureImperatively()
    {
        // Fixture setup
        var fixture = new Fixture()
            .Customize(new AutoFakeItEasyCustomization());
        var expectedRecord = fixture.Create<string>();
        var boundArgOption = fixture.Create<BoundArgumentOption>();
        var repositoryStub = A.Fake<IRepository>();
        A.CallTo(() => 
            repositoryStub
                .Get(boundArgOption))
                .Returns(expectedRecord);
            
        var repositoryFactoryStub = A.Fake<IRepositoryFactory>();
        A.CallTo(() => 
            repositoryFactoryStub
                .Create(boundArgOption))
                .Returns(repositoryStub);
            
        fixture.Inject(repositoryFactoryStub);
        var sut = fixture.Create<HtmlOutputBuilder>();
        // Exercise system
        string result = sut.BuildReport(boundArgOption);
            
        // Verify outcome
        result.Should().Be(expectedRecord);
            
        // Teardown
    }
