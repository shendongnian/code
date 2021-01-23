    public  class SystemUser
    {
      public int Id { get; set; }
      public string Name { get; set; } 
      public ICollection<SystemUserAccount> SystemUserAccounts{get;set;}
    }
     public class Account
    {
       public int Id { get; set; }
       public ICollection<SystemUserAccount> SystemUserAccount { get; set; }
    }
    public class SystemUserAccount
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
         
        public SystemUser SystemUser { get; set; }
        public Account UserAccount { get; set; }
    }
    
    public class AccountRole
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<SystemUserAccount> UserAccounts { get; set; }
    }
