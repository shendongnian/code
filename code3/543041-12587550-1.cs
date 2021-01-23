    public static HttpContextBase HttpContext()
    {
        var context = MockRepository.GenerateMock<HttpContextBase>();
        context.Stub(r => r.Request).Return(HttpRequest());
        context.Stub(r => r.Response).Return(HttpResponse());
        context.Stub(r => r.Session).Return(HttpSession());
        context.Stub(r => r.Server).Return(HttpServer());
        return context;
    }
    private static HttpServerUtilityBase HttpServer()
    {
        var httpServer = MockRepository.GenerateMock<HttpServerUtilityBase>();
        httpServer.Stub(r => r.MapPath("")).IgnoreArguments().Return("");
        return httpServer;
    }
    
    private static HttpResponseBase HttpResponse()
    {
        var httpResponse = MockRepository.GenerateMock<HttpResponseBase>();
        var cookies = new HttpCookieCollection {new HttpCookie("UserContext")};
        httpResponse.Stub(r => r.Cookies).Return(cookies);
        Func<string, string> returnWhatWasPassed = x => x;
        httpResponse.Stub(r => r.ApplyAppPathModifier("")).IgnoreArguments().Do(returnWhatWasPassed);
        return httpResponse;
    }
    public static HttpRequestBase HttpRequest()
    {
        var httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
        var cookies = new HttpCookieCollection {new HttpCookie("UserContext")};
        httpRequest.Stub(r => r.Cookies).Return(cookies);
        var parameters = new NameValueCollection {{"id", "277"}, {"binderId", "277"}};
        httpRequest.Stub(r => r.Params).Return(parameters);
        httpRequest.Stub(r => r.ApplicationPath).Return("/");
        httpRequest.Stub(r => r.AppRelativeCurrentExecutionFilePath).Return("~/");
        httpRequest.Stub(r => r.PathInfo).Return("");
        var serverVariables = new NameValueCollection();
        httpRequest.Stub(r => r.ServerVariables).Return(serverVariables);
        return httpRequest;
    }
    
    public static HttpSessionStateBase HttpSession()
    {
        var s =  new FakeSessionState();
        s["mocking"] = "true";
        return s;
    }
