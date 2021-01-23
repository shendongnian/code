    public async Task<string> MakeWebRequest(string url)
    {
        HttpClient http = new System.Net.Http.HttpClient();
        HttpResponseMessage response = await http.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
