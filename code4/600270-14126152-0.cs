    [ServiceContract]
    public interface IService
    {
      [OperationContract]
      string GetData(int value);
    
      [OperationContract]
      string GetDataResponse(int value);
    }
