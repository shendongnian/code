	using (var httpClient = new HttpClient())
    {
        var response = new HttpClient().PostAsJsonAsync(posturi, model).Result;
        bool returnValue = response.Content.ReadAsAsync<bool>().Result;
    }
