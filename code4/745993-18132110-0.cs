    private HttpRequestMessage CreateRequest<T>(T content, HttpMethod method) where T : class
    {
        var request = CreateRequest(method);
        var encoding = Encoding.UTF8;
        var xmlWriterSettings = new XmlWriterSettings { Indent = true, Encoding = encoding };
        // StringWriterWithEncoding courtesy of http://stackoverflow.com/a/9459212/29
        using (var stringWriter = new StringWriterWithEncoding(encoding))
        using (var xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(xmlWriter, content);
            request.Content = new StringContent(stringWriter.ToString(), encoding);
        }
        return request;
    }
