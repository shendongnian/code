    [TestMethod]
    public void HandleRequest_ShouldLogIdAndText()
    {
        // Arrange
        var handler = new TweetHandler();
        var mockRequest = new Mock<ITweetReq>();
        var mockLogger = new Mock<ILogger>();
    
        mockRequest.Setup(x => x.Id).Returns(10);
        mockRequest.Setup(x => x.Text).Returns("some text");
        
        // Act
        handler.HandleRequest(mockRequest, mockLogger);
    
        // Assert
        mockLogger.Verify(x => x.Log("Received tweet 10 with text: some text"));
    }
    [TestMethod]
    public void SendResponse_ShouldLogId()
    {
        // Arrange
        var handler = new TweetHandler();
        var mockResponse = new Mock<ITweetRes>();
        var mockLogger = new Mock<ILogger>();
    
        mockResponse.Setup(x => x.Id).Returns(20);
        
        // Act
        handler.SendReponse(mockResponse, mockLogger);
    
        // Assert
        mockLogger.Verify(x => x.Log("Sending response to tweet: 20"));
    }
