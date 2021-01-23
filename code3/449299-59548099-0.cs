    string postData;
    using (var stream = await request.Content.ReadAsStreamAsync())
    {
        stream.Seek(0, SeekOrigin.Begin);
        using (var sr = new StreamReader(stream))
        {
            postData = await sr.ReadToEndAsync();
        }
    }
