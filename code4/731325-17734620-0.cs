    HttpClient client = new HttpClient {
        BaseAddress = new Uri("http://localhost")
    };
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    HttpResponseMessage response = await client.GetAsync("relativeActionUri", content);
    string json = await response.Content.ReadAsStringAsync();
    accountInfo user1 = JsonConvert.DeserializeObject<accountInfo>(json);
