            // MockHttpSession Setup
            var session = new MockHttpSession();
            // MockHttpRequest Setup - mock AJAX request
            var httpRequest = new Mock<HttpRequestBase>();
            
            // Setup this part of the HTTP request for AJAX calls
            httpRequest.Setup(req => req["X-Requested-With"]).Returns("XMLHttpRequest");
            // MockHttpContextBase Setup - mock request, cache, and session
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(ctx => ctx.Request).Returns(httpRequest.Object);
            httpContext.Setup(ctx => ctx.Cache).Returns(HttpRuntime.Cache);
            httpContext.Setup(ctx => ctx.Session).Returns(session);
            // MockHttpContext for cache
            var contextRequest = new HttpRequest("", "http://localhost/", "");
            var contextResponse = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(contextRequest, contextResponse);
            // MockControllerContext Setup
            var context = new Mock<ControllerContext>();
            context.Setup(ctx => ctx.HttpContext).Returns(httpContext.Object);
            //TODO: Create new controller here
            //      Set controller's ControllerContext to context.Object
