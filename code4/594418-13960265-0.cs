    public async Task<List<string>> Testing()
    {
        var uri1 = new Uri("http://www.google.com");
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(uri1);
            return (await response.Content.ReadAsAsync<List<string>>());
        }
    }
