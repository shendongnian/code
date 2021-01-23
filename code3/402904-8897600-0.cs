    [ServiceContract(CallbackContract = typeof(IMyService_Callback))]
    public interface IMyService
    {
        [OperationContract]
        bool Subscribe();
    }
    [ServiceContract]
    public interface IMyService_Callback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyClient(string message);
    }
