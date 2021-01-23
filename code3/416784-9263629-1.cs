    var request = new Mock<HttpRequestBase>();
    request.SetupGet(c => c.Headers).Return(new NameValueCollection{ /* initialize values here */});
    request.SetupGet(c => c.IsSecureConnection).Return(/*specify true or false depending on your test */);
    
    var httpContext = new Mock<HttpContextBase>();
    httpContext.SetupGet(c => c.Request).Return(request.Object);
    
    
    var filterContext = new Mock<AuthorizationContext>();
    context.SetupGet(c => c.HttpContext).Return(httpContext.Object);
    
    var myclass = new myClass();
    myClass.OnAuthorization(filterContext.Object);
