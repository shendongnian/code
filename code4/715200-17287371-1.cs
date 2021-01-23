    // Prepare
    var context = new Mock<HttpContextBase>();
    var request = new Mock<HttpRequestBase>();
    var response = new Mock<HttpResponseBase>();
    var session = new Mock<HttpSessionStateBase>();
    var server = new Mock<HttpServerUtilityBase>();
    context.SetupGet(c => c.Request).Returns(request.Object);
    context.SetupGet(c => c.Response).Returns(response.Object);
    context.SetupGet(c => c.Session).Returns(session.Object);
    context.SetupGet(c => c.Server).Returns(server.Object);
    request.SetupGet(r => r.HttpMethod).Returns("GET");
    request.SetupGet(r => r.PathInfo).Returns(String.Empty);
    request.SetupGet(r => r.AppRelativeCurrentExecutionFilePath).Returns("~/Home");
    var expectedHandler = typeof (HomeController).GetMethod("Get", Type.EmptyTypes);
            
    var data = RouteTable.Routes.GetRouteData(context.Object);
    Assert.NotNull(data);
    var handler = (MethodInfo) data.DataTokens["actionMethod"];
    Assert.Equal(expectedHandler, handler);
