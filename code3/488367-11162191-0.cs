    [ServiceContract]
    public interface IContract
    {
       [OperationContract]
       [ServiceKnownType(typeof(HttpUnhandledException))]
       void PassException(Exception c);
    }
