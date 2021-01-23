    [ServiceContract(Name = "Service", Namespace = "http://stackoverflow.com/2012/03")]
    public interface IServiceOld
    {
        [OperationContract]
        void DoWork();
    }
    [ServiceContract(Name = "Service", Namespace = "http://stackoverflow.com/2012/04")]
    public interface IServiceNew
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        void DoAdditionalWork();
    }
