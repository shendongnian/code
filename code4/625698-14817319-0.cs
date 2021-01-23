    public class Message
    {
        public static Message CreateInstance(int id, Message parent)
        {
            // Add code here to check security of caller
            return new Message(id, parent);
        }
        private Message(int id, Message parent)  
        {
            ID = id;
            Parent = parent;
        }
        public int ID { get; private set; }
        public Message Parent { get; private set; }
    }
