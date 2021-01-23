    [Test(Description = "Test If can successfully add application")]
    public void CanAddApplication()
    {
        var repo = GetRepo();
        var appService = new ApplicationService(repo);
        // do the test....
    }
    private static IEntityFrameworkRepo GetRepo{
        /create a mock repository
        var repo = new Mock<IEntityFrameworkRepo >();
        // setup the methods you know you will need for testing
        repo.Setup(x => x.SomeMethod()).Returns(IEnumerable<applicationDto.Object>);
        return repo.Object;
    }
