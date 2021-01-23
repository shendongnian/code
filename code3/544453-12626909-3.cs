    [ServiceContract]
    public interface IMyApi
    {
        [OperationContract]
        string SayHello(string s);
    }
