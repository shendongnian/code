    public interface IMyCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void NotifyClient();
    }
    [ServiceContract(CallbackContract = typeof(IMyCallbackService))]
    public interface ISimpleService
    {
        [OperationContract]
        string ProcessData();
    }
