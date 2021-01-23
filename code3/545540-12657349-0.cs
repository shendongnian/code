    [ServiceContract]
    public interface IMyService
    {
        [OperationContract(IsOneWay=true)]
        void IAmALongRunningMethodAndIDontCareToReturnAnything();
    }
