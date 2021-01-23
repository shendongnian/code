    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string firstName, string lastName);
    }
