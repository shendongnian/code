	using (var httpClient = new HttpClient())
    {
        var response = httpClient.PostAsJsonAsync("", true).Result;
        bool returnValue = response.Content.ReadAsAsync<bool>().Result;
    }
