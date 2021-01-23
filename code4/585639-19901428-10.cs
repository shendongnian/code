    [ServiceContract(Namespace = "http://test")]
    public interface ITestService
    {
    [OperationContract]
    [WebGet(UriTemplate = "accounts/{id}")]
    Account[] GetAccount(string id);
    }
