    using (var client = new WebClient())
    {
        client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17";
        using (var stream = client.OpenRead(url))
        using (var reader = XmlReader.Create(stream))
        {
            while (reader.Read())
            {
                // ...
            }
        }
    }
