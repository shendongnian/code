         public class Account
    {
        [Key]
        [ForeignKey("BlockedAccount")]
        public virtual Guid AccountId { get; set; }
        public virtual string UserName { get; set; }
        public virtual BlockedAccount BlockedAccount { get; set; }
    }
    public class BlockedAccount
    {
        [Key]
        public virtual Guid BlockedAccountId { get; set; }
        public virtual int BanLevel { get; set; }
        public virtual DateTime BannedDate { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual string Reason { get; set; }
        public BlockedAccount()
        {
            BannedDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
        }
    }
    public class Model : DbContext
    {
        public DbSet<BlockedAccount> BlockedAccounts { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b = new BlockedAccount()
                {
                   BlockedAccountId = Guid.NewGuid()
                };
            var a = new Account();
            a.BlockedAccount = b;
            Model m = new Model();
            m.Accounts.Add(a);
            m.SaveChanges();
        }
    }
