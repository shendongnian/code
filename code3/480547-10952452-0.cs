    static async Task<JsonValue> DownloadJsonAsync(string url)
    {
        var client = new HttpClient();
        client.MaxResponseContentBufferSize = 1024 * 1024;
        var data = await client.GetByteArrayAsync(new Uri(url));
        var encoding = Encoding.UTF8;
        var preamble = encoding.GetPreamble();
        var content = encoding.GetString(data, preamble.Length, data.Length - preamble.Length);
        var result = JsonValue.Parse(content);
        return result;
    }
