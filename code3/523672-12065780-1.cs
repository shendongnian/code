    [OperationContract]
    [WebGet(UriTemplate = "TestMethod")]
    Stream TestMethod();
    public Stream TestMethod()
    {
        byte[] data = GetData();
        MemoryStream stream = new MemoryStream(data);
        WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg"; //or whatever your mime type is
        stream.Position = 0;
        return stream;
    }
