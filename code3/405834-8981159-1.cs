    [Test]
    public void ValidateClient_WhenValid_ReturnsEmptyString()
    {
        // Arrange
        const int UserId = 1234;
        var mockRepo = new Mock<IUserRepository>();
        var user = new User();
        mockRepo.Setup(x => x.TryGetById(UserId, out user)).Returns(true);
        var sut = new SomeBusinessLogic(mockRepo.Object);
        
        // Act
        string result = sut.ValidateClient(UserId);
        
        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }
    
    [Test]
    public void ValidateClient_WhenInvalid_ReturnsMessage()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        var sut = new SomeBusinessLogic(mockRepo.Object);
        
        // Act
        string result = sut.ValidateClient(1234);
        
        // Assert
        Assert.That(result, Is.EqualTo("ClientId does not match."));
    }
