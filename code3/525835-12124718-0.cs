    public class Message
    {
        ...
        public virtual User From { get; set; }
        public virtual IEnumerable<UsersToMessage> To { get; set; }
    }
