    public static class MessageHandlerRegistry
    {
        private static readonly IDictionary<Type, object> _handlers = new Dictionary<Type, object>();
        public static void Publish<T>(T m) where T : Message
        {
            if (_handlers.ContainsKey(typeof (T)))
            {
                ((MessageHandler<T>) _handlers[typeof (T)]).Publish(m);
            }
        }
        public static void Subscribe<T>(MessageHandler<T>.MessageDelegate messageHandler) where T : Message
        {
            if (!_handlers.ContainsKey(typeof (T)))
            {
                _handlers[typeof (T)] = new MessageHandler<T>();
            }
            ((MessageHandler<T>) _handlers[typeof (T)]).Subscribe(messageHandler);
        }
    }
