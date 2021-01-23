    public class MessageManager
    {
        private IMessage _message;
        // depend only on abstraction 
        // no references to interface implementations should be here
        public IMessage Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public MessageManager(IMessage message)
        {
            _message = message;
        }
    }
