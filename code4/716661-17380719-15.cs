    [ServiceContract]
    public interface IService3
    {
        [OperationContract(IsOneWay = true)]
        Task DoSomethingAsync(int value);
    }
