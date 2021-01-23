    [ServiceContract(Name = "RESTDemoServices")]
    public interface IRESTDemoServices
    {
        [OperationContract]
        string GetClientNameById(int Id);
    }
