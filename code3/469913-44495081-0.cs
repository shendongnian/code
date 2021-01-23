    HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, @"myUrl");
    httpRequest.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
    HttpClient client = new HttpClient();
    Task<HttpResponseMessage> response =  client.SendAsync(httpRequest);
    var result = response.Result;
