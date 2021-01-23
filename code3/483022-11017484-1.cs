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
    // if it is sensible, you can use the following interfaces to create definitive new and legacy message contracts
    public interface INewMessage : IMsg<INewMsgId>
    {
    }
    public interface ILegacyMessage : IMsg<ILegacyMsgId>
    {
    }
