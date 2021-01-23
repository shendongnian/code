    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void CreateReport(WebServiceParam parameters);
    }
