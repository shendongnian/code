    public class MessageHandler<T> where T : Message
    {
        public delegate void MessageDelegate(T m);
        private MessageDelegate messageHandlers;
        public void Publish(T message)
        {
            messageHandlers(message);
        }
        public void Subscribe(MessageDelegate messageHandler)
        {
            messageHandlers += messageHandler;
        }
    }
