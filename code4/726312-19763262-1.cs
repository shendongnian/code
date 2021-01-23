    private Mock<IABCRepository> mockRepo;
    private ABCModel model;
    [SetUp]
    public void SetUp()
    {
        mockRepo = new Mock<IABCRepository>();
    
        model = new ABCModel(mockRepo.Object);
    }    
    [Test]
    public void ABCToTest_WhenCalled_CallsRepository
    {       
        model.ABCToTest("177737");
        mockRepo.Verify(a => a.GetMyValues(), Times.Once);
    }
