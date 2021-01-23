    public interface  IMessage
    {
        string Content { get; }
    }
    [KnownType(typeof(Message))]
    public class Message : IMessage {
        public string Content{ get; set; }
    }
    [KnownType(typeof(Message2))]
    public class Message2 : IMessage
    {
        public string Content { get; set; }
    }
