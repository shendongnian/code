    [ServiceContract(Namespace = MyProxyProvider.MyNamespace)]
    [ServiceKnownType("GetKnownTypes", typeof(XHelper))]
    public interface MyService
    {
        [OperationContract]
        Thing2 CopyThing(Thing1 input);
    }
