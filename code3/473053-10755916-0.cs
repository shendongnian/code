    // Arrange
    var mockHttpContext = new Mock<HttpContextBase>();
    var response = new Mock<HttpResponseBase>();
    mockHttpContext.SetupGet(x => x.Response).Returns(response.Object);
    //creates an instance of an asp.net mvc controller
    var controller = new AppController()
    {
        ControllerContext = new ControllerContext() 
        { 
            HttpContext = mockHttpContext.Object 
        }
    };
    // Act
    controller.SetHttpStatusCode(HttpStatusCode.OK);
    //Assert
    response.VerifySet(x => x.StatusCode = (int)HttpStatusCode.OK);
