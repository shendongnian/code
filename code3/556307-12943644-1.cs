    // Create an HttpClient instance
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:8888/");
    
    // Usage
    response = client.GetAsync("api/importresults/1").Result;
    if (response.IsSuccessStatusCode)
    {
        var dto = response.Content.ReadAsAsync<ImportResultDTO>().Result;
    }
    else
    {
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }
