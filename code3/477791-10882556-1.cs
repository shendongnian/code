    var httpClient = new HttpClient();
    var url = new Uri("http://bing.com");
    var accessToken = "1234";
    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
    httpRequestMessage.Headers.Add(System.Net.HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", accessToken));
    httpRequestMessage.Headers.Add("User-Agent", "My user-Agent");
    var response = await httpClient.SendAsync(httpRequestMessage);
