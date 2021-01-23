    public class MessageHandler<T> where T : Message
    {
        private Action<T> messageHandlers;
        public void Publish(T message)
        {
            messageHandlers(message);
        }
        public void Subscribe(Action<T> messageHandler)
        {
            messageHandlers = (Action<T>) Delegate.Combine(messageHandlers, messageHandler);
        }
    }
