      using (var httpClient = new HttpClient())
      {
        var url = new Uri("http://bing.com");
        var accessToken = "1234";
        using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url))
        {
          httpRequestMessage.Headers.Add(System.Net.HttpRequestHeader.Authorization.ToString(),
            string.Format("Bearer {0}", accessToken));
          httpRequestMessage.Headers.Add("User-Agent", "My user-Agent");
          using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage))
          {
            // do something with the response
            var data = httpRequestMessage.Content;
          }
        }
      }
