    [ProtoContract, ProtoInclude(5001, typeof(LogonMessage))]
    abstract public class BaseMessage
    {
        abstract public int MessageType { get; }
    }
    
    
    [ProtoContract]
    public class LogonMessage : BaseMessage
    {
        [ProtoMember(1)]
        public string Broker { get; set; }
    
        [ProtoMember(2)]
        public int ClientType { get; set; }
    
        public override int MessageType
        {
            get { return 1; }
        }
    }
