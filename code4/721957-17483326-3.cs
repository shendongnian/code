    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        client.Headers[HttpRequestHeader.Accept] = "application/json";
        var data = Encoding.UTF8.GetBytes("{\"foo\":\"bar\"}");
        byte[] result = client.UploadData("http://example.com/values", "POST", data);
        string resultContent = Encoding.UTF8.GetString(result, 0, result.Length);        
