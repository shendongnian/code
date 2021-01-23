    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        client.Headers[HttpRequestHeader.Accept] = "application/json";
        var data = Encoding.UTF8.GetBytes("{\"foo\":\"bar\"}");
        byte[] result = client.UploadData("http://example.com/values", "POST", data);
        // now use a JSON parser to parse the resulting string back to some CLR object
    }
