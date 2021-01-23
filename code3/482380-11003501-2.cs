    [ServiceContract]
    public interface IMyService
    {
         [OperationContract]
         [WebGet(UriTemplate = "{docId}")]
         void GetData(string docId);
     }
