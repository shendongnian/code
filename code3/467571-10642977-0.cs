    var client = new HttpClient();
    var content = new StringContent(
        @"{""message"": ""this is a log message"" }",
        Encoding.UTF8,
        "application/json");
    var address = new Uri(_webApiBaseAddress + "logs/" + jobId);
    client.PutAsync(address, content).ContinueWith(task =>
    {
        task.Result.EnsureSuccessStatusCode();
    });
