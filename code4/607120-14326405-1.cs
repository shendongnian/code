    [OperationContract]
    [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/picture/{path}")]
    System.IO.Stream GetPictureMethod(string path);
    public System.IO.Stream GetPictureMethod(string path)
    {
        path = "(test path here)";
        byte[] picData = System.IO.File.ReadAllBytes(path);
        WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg"; // or the correct type
        return new System.IO.MemoryStream(picData);
    }
