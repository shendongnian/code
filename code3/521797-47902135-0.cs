    using (var client = new HttpClient())
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("some url"),
            Method = HttpMethod.Get,
        };
        request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("some json"));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // change as necessary
        var result = client.SendAsync(request).Result;
        result.EnsureSuccessStatusCode();
        var responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
