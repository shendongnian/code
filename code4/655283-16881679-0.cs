    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ServiceResponse Process( ServiceRequest request );
    }
    class ServiceRequest
    {
        public Guid RequestID { get; set; }
        public string RequestData { get; set; }
    }
    class ServiceResponse
    {
        public Guid RequestID { get; set; }
        public string ResponseData { get; set; }
    }
