    // be careful of disposing this client if you intend to make many requests
    // - see https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    using (var client = new HttpClient())
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("some url"),
            Method = HttpMethod.Get,
        };
        request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("some json"));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var result = client.SendAsync(request).Result;
        result.EnsureSuccessStatusCode();
        var responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
