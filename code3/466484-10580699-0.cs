    public interface IMyCode
    {
        string GetResult();
    }
    [ServiceContract]
    public interface IMyCodeService : IMyCode
    {
        [OperationContract]
        string GetResult();
    }
