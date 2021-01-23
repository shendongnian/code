     [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(UriTemplate="/CallADSWebMethod", Method="POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        string CallADSWebMethod(string vin, string styleID);
    }
