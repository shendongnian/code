    [OperationContract]
    [WebInvoke(
        Method = "POST",
        BodyStyle = WebMessageBodyStyle.Bare,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/fileUpload/?userId={userId}" )]
    public void UploadFile( int userId, Stream fileStream)
    {
        // Here you read the file from fileStream
    }
