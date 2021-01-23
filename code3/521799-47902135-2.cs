    // be careful of disposing this client if you intend to make many requests
    // - see https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    using (var client = new HttpClient())
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("some url"),
            Content = new StringContent("some json", Encoding.UTF8, ContentType.Json),
        };
        var result = client.SendAsync(request).Result;
        result.EnsureSuccessStatusCode();
        var responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
