    public static class ContextHelper
    {
        public static HttpContextBase FakeHttpContext(string relativePath, string absolutePath, params string[] routePaths)
        {
            var httpContext = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var cookies = new HttpCookieCollection();
            httpContext.Setup(x => x.Server).Returns(server.Object);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            httpContext.Setup(x => x.Request).Returns(request.Object);
            httpContext.Setup(x => x.Response).Returns(response.Object);
            response.Setup(x => x.Cookies).Returns(cookies);
            httpContext.SetupGet(x => x.Request.Url).Returns(new Uri("http://localhost:300"));
            httpContext.SetupGet(x => x.Request.UserHostAddress).Returns("127.0.0.1");
            if (!String.IsNullOrEmpty(relativePath))
            {
                server.Setup(x => x.MapPath(relativePath)).Returns(absolutePath);
            }
            // used for matching routes within calls to Url.Action
            foreach (var path in routePaths)
            {
                var localPath = path;
                response.Setup(x => x.ApplyAppPathModifier(localPath)).Returns(localPath);
            }
            var writer = new StringWriter();
            var wr = new SimpleWorkerRequest("", "", "", "", writer);
            HttpContext.Current = new HttpContext(wr);
            return httpContext.Object;
        }
    }
