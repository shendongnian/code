    public enum messageType
    {
        Sms, Mms
    }
    
    public class Message
    {
        public MessageType MessageType { get; get; }
        public string Data { get; set; } // assume data to be processed
    }
    
    
    interface IHandler
    {
        void Process(Message message);
    }
    
    class SmsHander : IHandler
    {
        void Process(Message message)
        {}
    }
    
    class MmsHander : IHandler
    {
        void Process(Message message)
        {}
    }
    
    class MessageProcessor
    {
        private Dictionary<MessageType, IHandler> 
                       handlers = new Dictionary<MessageType, IHandler>()
        {
            { MessageType.Sms, new SmsHander() },
            { MessageType.Mms, new MmsHander() },
        };
    
        public void Process(Message message)
        {
            handlers[message.MessageType].Process(message);
        }
    }
