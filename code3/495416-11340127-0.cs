    interface ITest2
    { 
        [OperationContract]
        int Add(int x, int y);
    }
    [ServiceContract]
    interface ITest2Service : ITest2 { }
