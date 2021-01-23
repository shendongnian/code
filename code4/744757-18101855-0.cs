                var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/a", UriKind.Absolute));
            request.SetupGet(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());
            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            response.Setup(x => x.ApplyAppPathModifier(Moq.It.IsAny<String>())).Returns((String url) => url);
            // response.SetupGet(x => x.Cookies).Returns(new HttpCookieCollection()); // This also failed to work
            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);
            context.SetupGet(x => x.Response.Cookies).Returns(new HttpCookieCollection()); // still can't call the Clear() method
            context.SetupGet(p => p.User.Identity.Name).Returns("blah");
            context.SetupGet(p => p.User.Identity.IsAuthenticated).Returns(true);
            var rc = new RequestContext(context.Object, new RouteData());
            
            controller.ControllerContext = new ControllerContext(rc, controller);
