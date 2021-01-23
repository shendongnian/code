    public class User
    {
        [Key]
        public int UserId { get; set; }
        virtual public ICollection<Transaction> SenderTransactions { get; set; }
        virtual public ICollection<Transaction> ReceiverTransactions { get; set; }
    }
