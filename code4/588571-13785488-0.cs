        Uri baseUri = new Uri("http://www.test.com/");
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.CookieContainer.Add(baseUri, new Cookie("name", "value"));
        HttpClient client = new HttpClient(clientHandler);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = baseUri;
        HttpResponseMessage response = await client.GetAsync("http://www.test.com" + URL);
        string str2 = await response.Content.ReadAsStringAsync();
