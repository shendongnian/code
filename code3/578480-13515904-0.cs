    public async Task<string> GetjsonStream()
    {
        HttpClient client = new HttpClient();
        string url = "http://(urlHere)";
        HttpResponseMessage response = await client.GetAsync(url);
        string content = await response.Content.ReadAsStringAsync();
        Debug.WriteLine("Content: " + content);
        return content;
    }
