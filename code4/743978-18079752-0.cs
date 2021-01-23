    public class SentMessage : Message, IMessage
    {
        public SentMessage(int id, string userName, string message, string messageType, DateTime createdAt)
        {
            Id = id;
            UserName = userName;
            Message = message;
            CreatedAt = createdAt;
            MessageType = messageType;
        }
        public string UserName { get; private set; }
        public int Id { get; private set; }
        public string Message { get; private set; }
        public string MessageType { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
    
    public class MessageCollection<T> where T : IMessage
    {
        private List<T> _messages;
        public MessageCollection()
        {
           _messages = new List<T>();
        }
    
        public IEnumerable<T> GetMessages()
        {
            return _messages;
        }
        public void AddMessage(T message)
        {
            _messages.Add(message);
        }
    
        public void ClearMessages()
        {
            _messages.Clear();
        }
    }
