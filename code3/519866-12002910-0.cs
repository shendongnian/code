    public class Message
    {
        public string Time { get; private set; }
        public string Content { get; private set; }
        public Message(string time, string content)
        {
            Time = time;
            Content = content;
        }
    }
