    public class Message
    {
        public Message(int id, Message parent) // Message constructor taking in ID and parent from external
        {
            ID = id;
            Parent = parent;
        }
        public int ID { get; private set; }
        public Message Parent { get; private set; }
    }
