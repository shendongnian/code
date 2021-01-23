    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://example.com");
        var result = client.PostAsync("/api/performances", new
        {
            id = 1,
            date = DateTime.Now,
            value = 1.5
        }, new JsonMediaTypeFormatter()).Result;
        if (result.IsSuccessStatusCode)
        {
            Console.writeLine("Performance instance successfully sent to the API");
        }
        else
        {
            string content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("oops, an error occurred, here's the raw response: {0}", content);
        }
    }
