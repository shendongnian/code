    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    void newUserAndImageEntry(string pArrayImageAsBase64, string pContentType,
        string pUserName, string pFileName);
