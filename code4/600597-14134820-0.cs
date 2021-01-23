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
    
    // now you can act and run your assertions.
