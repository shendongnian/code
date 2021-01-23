    public string SafelyReadContent(HttpRequestMessage request)
    {
        var stream = request.Content.ReadAsStreamAsync().Result;
        var reader = new StreamReader(stream);
        var result = reader.ReadToEnd();
        stream.Seek(0, SeekOrigin.Begin);
        return result;
    }
