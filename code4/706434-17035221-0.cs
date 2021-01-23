    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string name { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
    class Program
    {
        static Guid MyGuid = Guid.Empty;
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                Account account = new Account { name = "OldName" };
                context.Accounts.Add( account );
                context.SaveChanges();
                MyGuid = account.ID;
            }
            using (var context = new MyContext())
            {
                var account = context.Accounts.Where(x => x.ID == MyGuid).FirstOrDefault();
                if (account != null)
                {
                    account.name = "UpdatedName";
                    context.SaveChanges();
                }
            }
        }
    }
