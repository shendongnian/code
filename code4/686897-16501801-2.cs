    [ServiceContract]
    public interface IFooService
    {
        [OperationContract]
        string FooMethod1();
        [OperationContract]
        string FooMethod2();
    }
