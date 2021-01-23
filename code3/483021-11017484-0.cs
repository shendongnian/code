    public interface IMsgId
    {
     // ?
    }
    
    public interface INewMsgId : IMsgId
    {
    }
    
    public interface ILegacyMsgId : IMsgId
    {
    }
    
    public interface IMsg<TId>
       where TId : IMsgId
    {
       TId MessageId { get; }
    
       byte[] MsgBytes { get; }
    }
