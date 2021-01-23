    public enum MessageType
    {
        DEFAULT = 0
    }
    [Serializable]
    public class Message
    {
        public MessageType type;
        public string from;
        public string to;
        public string content;
    }
