    // NOTE: This is the std wcf template
    [ServiceContract]
    public interface IService1
    {
        [FaultContract(typeof(int))]
        [FaultContract(typeof(string))]
        [FaultContract(typeof(DateTime))]
        [OperationContract]
        string GetData(int value);
    }
