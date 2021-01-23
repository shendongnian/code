    private HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method)
    {
        var request = new HttpRequestMessage();
        var baseRequest = new Mock<HttpRequestBase>(MockBehavior.Strict);
        var baseContext = new Mock<HttpContextBase>(MockBehavior.Strict);
        baseRequest.Setup(br => br.UserHostAddress).Returns("127.0.0.1");
        baseContext.Setup(bc => bc.Request).Returns(baseRequest.Object);
        
        request.RequestUri = new Uri(url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
        request.Properties.Add("MS_HttpContext", baseContext.Object);
        request.Method = method;
        return request;
    } 
