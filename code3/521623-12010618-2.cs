    public class User
    {
        public int UserId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
    
    public class UserAccount
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    
        public virtual User User { get; set; }
    
    }
    
    public class AccountRole
    {
        public int AccountRoleId { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
