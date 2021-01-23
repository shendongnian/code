    public async Task<bool> Post(IEnumerable<KeyValuePair<string, string>> headers, string data)
    {
        HttpClient client = new HttpClient(new HttpClientHandler {AllowAutoRedirect = false});
        foreach (var header in headers)
        {
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
        try
        {
            var result = await client.PostAsync(endpoint, new StringContent(data, Encoding.UTF8, "text/xml")).ConfigureAwait(false);
            return result.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
