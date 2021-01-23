    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        MixedServerandClientSideData DoWork();
    }
