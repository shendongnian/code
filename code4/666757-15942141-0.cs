    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string GetData(int value);
    }
