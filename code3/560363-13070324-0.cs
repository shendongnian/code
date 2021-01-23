    [ServiceContract]
    public interface ITestService
    {
        [WebGet(UriTemplate = "Tester")]
        [OperationContract]
        Stream Tester();
    }
