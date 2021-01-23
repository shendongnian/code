    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    void newUserAndImageEntry(byte[] pArrayImage, string pContentType,
        string pUserName, string pFileName);
