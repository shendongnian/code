    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ScreenDto[] GetData(DateTime d);
    }
    
