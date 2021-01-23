    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url)
    {
        Content = content
    };
    message.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
    httpClient.SendAsync(message);
