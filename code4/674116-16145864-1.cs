    namespace WcfService1
    {
    [ServiceContract]
    public interface IMyService
    {
        [WebGet(UriTemplate = "Test",
            ResponseFormat = WebMessageFormat.Json
        )]
        [OperationContract]
        string Test();
    }
    }
