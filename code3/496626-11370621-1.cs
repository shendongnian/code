    public interface IMessage
    {
        int TransactionId { get; }
    }
    
    public class UserListMessage : IMessage
    {
        int TransactionId { get; set; }
        public List<string> Users { get; set; }
    }
