    // arrange
    var httpContext = MockRepository.GenerateMock<HttpContextBase>();
    var request = MockRepository.GenerateMock<HttpRequestBase>();
    var response = MockRepository.GenerateMock<HttpResponseBase>();
    
    // stub both Request and Response, for good measure.
    httpContext.Stub(x => x.Request).Return(request);
    httpContext.Stub(x => x.Response).Return(response);           
    
    var controller = new YourController();
    
    // create and assign the controller context
    var context = new ControllerContext(httpContext, 
                      new RouteData(), 
                      controller);
    controller.ControllerContext = context;
    
    // act
    var actual = controller.UnderConstruction() as ViewResultBase;
    // assert
    Assert.That(actual, Is.Not.Null);
    Assert.That(controller.Response.StatusCode, Is.EqualTo(HttpStatusCode.TemporaryRedirect));
    // etc.    
