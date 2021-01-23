    var userMock = new Mock<IPrincipal>();
    userMock.Setup(p => p.IsInRole("admin").Returns(true);
    userMock.SetupGet(p => p.Identity.Name).Returns("tester");
    userMock.SetupGet(p => p.Identity.IsAuthenticated).Returns(true);
    var requestContext = new Mock<HttpRequestContext>();
    requestContext.Setup(x => x.Principal).Returns(userMock.Object);
    var controller = new ControllerToTest()
    {
        RequestContext = requestContext.Object,
        Request = new HttpRequestMessage(),
        Configuration = new HttpConfiguration()
    };
