    [ServiceContract]
    public interface IService1
    {
        [...]
        // TODO: Add your service operations here
        [OperationContract]
        string GetToken(string userName, string password);
    }
