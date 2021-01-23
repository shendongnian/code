    for (int i = 1; i < 6; i++)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        int id = i;
        Console.WriteLine("{0} started", id);
        var result = client.SendAsync(request)
            .ContinueWith(t =>
            {
                Console.WriteLine("{0} reading", id);
                return t.Result.Content.ReadAsStringAsync();
            })
            .Unwrap()
            .ContinueWith(t =>
            {
                Console.WriteLine("{0} read", id);
                var deserialized = JsonConvert.DeserializeObject<JsonResult<MyResult>>(t.Result);
                Console.WriteLine("{0} deserialized", id);
                return deserialized;
            });
    }
