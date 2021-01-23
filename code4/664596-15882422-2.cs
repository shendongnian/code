    // arrange
    var contextMock = Substitute.For<HttpContextBase>();
    var requestMock = Substitute.For<HttpRequestBase>();
    var queryString = new NameValueCollection();
    queryString["foo"] = "bar";
    requestMock.QueryString.Returns(queryString);
    contextMock.Request.Returns(requestMock);
    var sut = new SomeController();
    sut.ControllerContext = new ControllerContext(contextMock, new RouteData(), sut);
    // act
    var actual = sut.SomeAction(); 
    // assert
    ...
