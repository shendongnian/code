    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Screen_Data[] GetData(DateTime d);
    }
    
