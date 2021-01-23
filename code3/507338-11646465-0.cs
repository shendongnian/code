    [ServiceContract(Namespace = "http://localhost/SkruvWeb/Service")]
    [ServiceKnownType(typeof(String))]
    public interface IQueueMessageReceiver
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void PutScrewInfoMessage(MsmqMessage<string> msg);
    }
