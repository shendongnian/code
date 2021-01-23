    [ServiceContract]
    public interface IBarService
    {
        [OperationContract]
        string BarMethod1();
        [OperationContract]
        string BarMethod2();
    }
