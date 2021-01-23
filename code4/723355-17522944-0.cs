    var contextMock=new Mock<ControllerContext>();
    var mockHttpContext = new Mock<HttpContextBase>();
    var Session = new HttpSessionStatebase();
    mockHttpContext.Setup(h=>h.Session).Returns(Session);
    contextMock.Setup(c=>c.HttpContext).Returns(mockHttpContext.Object);
