    HttpClient c = new HttpClient();
    c.BaseAddress = new Uri("http://example.com/");
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
    req.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}", Encoding.UTF8, "application/json");
    c.SendAsync(req).ContinueWith(respTask =>
    {
        Console.WriteLine("Response: {0}", respTask.Result);
    });
