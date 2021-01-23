    var contextMock = new Mock<ControllerContext>();
    var mockHttpContext = new Mock<HttpContextBase>();
    var session = new Mock<HttpSessionStateBase>();
    mockHttpContext.Setup(h => h.Session).Returns(session.Object);
    contextMock.Setup(c => c.HttpContext).Returns(mockHttpContext.Object);
