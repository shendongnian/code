    var baseAddress = new Uri("http://example.com");
    using (var handler = new HttpClientHandler { UseCookies = false })
    using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
    {
        var message = new HttpRequestMessage(HttpMethod.Get, "/test");
        message.Headers.Add("Cookie", "cookie1=value1; cookie2=value2");
        var result = await client.SendAsync(message);
        result.EnsureSuccessStatusCode();
    }
