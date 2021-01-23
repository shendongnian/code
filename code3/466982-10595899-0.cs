    User (1) <-------> (0..*) Account
    public class User
    {
        public virtual ICollection<Account> Accounts { get; protected internal set; }
    }
    public class Account
    {
        public virtual int UserId { get; protected internal set; }
        public virtual User User { get; set; }
    }
