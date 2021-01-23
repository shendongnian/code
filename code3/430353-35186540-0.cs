            // MockHttpSession Setup
            var session = new MockHttpSession();
            // MockHttpRequest Setup - mock AJAX request
            var httpRequest = new Mock<HttpRequestBase>();
            httpRequest.Setup(c => c["X-Requested-With"]).Returns("XMLHttpRequest");
            // MockHttpContextBase Setup - mock request, cache, and session
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.Request).Returns(httpRequest.Object);
            httpContext.Setup(c => c.Cache).Returns(HttpRuntime.Cache);
            httpContext.Setup(c => c.Session).Returns(session);
            // MockHttpContext for cache
            var contextRequest = new HttpRequest("", "http://localhost/", "");
            var contextResponse = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(contextRequest, contextResponse);
            // MockControllerContext Setup
            var context = new Mock<ControllerContext>();
            context.Setup(c => c.HttpContext).Returns(httpContext.Object);
