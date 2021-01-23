    [ServiceContract]
    public interface MyContract
    {
        [OperationContract]
        void MyOperation(string param1, int param2);
        [OperationContract]
        void MyOtherOperation(int param1, out int outputParam);
    }
