    var request = WebRequest.CreateHttp(baseUrl + "$metadata");
    var metadataMessage =
        new ClientHttpResponseMessage((HttpWebResponse)request.GetResponse());
    using (var messageReader = new ODataMessageReader(metadataMessage))
    {
        IEdmModel edmModel = messageReader.ReadMetadataDocument();
        // Do stuff with edmModel here
    }
