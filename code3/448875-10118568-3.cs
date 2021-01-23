    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypeHelper))]
    public interface IMyService
    {
        [OperationContract]
        object TakeMessage( );
    
        [OperationContract]
        void AddMessage(object contract);
    }
