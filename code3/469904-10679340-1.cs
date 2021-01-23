    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://example.com/");
    client.DefaultRequestHeaders
          .Accept
          .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
    request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                                        Encoding.UTF8, 
                                        "application/json");
    
    client.SendAsync(request)
          .ContinueWith(responseTask =>
          {
              Console.WriteLine("Response: {0}", responseTask.Result);
          });
