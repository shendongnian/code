    [ServiceContract]
    public interface IMyService_Callback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyClients(string message);
    }
    
    [ServiceContract(CallbackContract = typeof(IMyService_Callback))]
    public interface IMyService
    {
        [OperationContract]
        bool Subscribe();
    }
