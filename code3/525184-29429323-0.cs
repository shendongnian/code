    var body = string.Empty;
    using (var reader = new StreamReader(request.Content.ReadAsStreamAsync().Result))
    {
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        body = reader.ReadToEnd();
    }
