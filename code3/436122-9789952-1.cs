    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://test.com");
    httpRequestMessage.Headers.Add("username", "test");
    var handler = new MyHandler()
    {
        InnerHandler = new TestHandler((r,c) =>
        {
            Assert.That(r.Headers.Contains("username"));
            return TestHandler.Return200();
        })
    };
    var client = new HttpClient(handler);
    var result = client.SendAsync(httpRequestMessage).Result;
    Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
