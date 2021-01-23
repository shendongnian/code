    [System.ServiceModel.Web.WebGet( UriTemplate = "c" , BodyStyle = WebMessageBodyStyle.Bare )]
    [OperationContract]
    public System.IO.Stream Connect()
    {
        string result = "<a href='someLingk' >Some link</a>";
        byte[] resultBytes = Encoding.UTF8.GetBytes(result);
        WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
        return new MemoryStream(resultBytes);
    }
