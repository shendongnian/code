    [Test]
    public void Hello_I_Want_to_test_ponies()
    {
        Mock<IRepository<Pony> _mockPonyRepo = new Mock<IRepository<Pony>>();
        _mockPonyRepo.SetUp(m => m.GetAll()).Returns(FakeStuff.JustSomeGenericPonies(50));
        // Do things that test using the repository
    }
