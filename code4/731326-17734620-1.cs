    HttpMessageHandler handler = new HttpClientHandler { CookieContainer = yourCookieContainer };
    HttpClient client = new HttpClient(handler) {
        BaseAddress = new Uri("http://localhost")
    };
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    HttpContent content = new StringContent("dataForTheServerIfAny");
    
    HttpResponseMessage response = await client.GetAsync("relativeActionUri", content);
    string json = await response.Content.ReadAsStringAsync();
    accountInfo user1 = JsonConvert.DeserializeObject<accountInfo>(json);
