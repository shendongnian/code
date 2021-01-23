    public class X : BasicDTO
    public class Y : BasicDTO
    [ServiceContract]
    [ServiceKnownType(typeof(X))]
    [ServiceKnownType(typeof(Y))]
    public interface IDataToMfcV2
    {       
        [OperationContract(IsOneWay = false)]
        SecurityAnswerDTO CommitDTOs(string sessionId, BasicDTO[] basicDto);        
    }
