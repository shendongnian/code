    [ServiceKnownType(typeof(Client))]
    [ServiceContract()]
    public interface IMyServiceContract
    {
        
        [OperationContract]
        Contact GetContact();
    }
