    [OperationContract]
    [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/picture/{path}")]
    System.IO.Stream GetPictureMethod(string path);
    public System.IO.Stream GetPictureMethod(string path)
    {
        path = "(test path here)";
        byte[] picData = System.IO.File.ReadAllBytes(path);
        return new System.IO.MemoryStream(picData);
    }
