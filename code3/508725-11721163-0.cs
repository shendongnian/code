    internal class Program
    {
        private static void Main()
        {
            EntityFrameworkProfiler.Initialize();
            Database.DefaultConnectionFactory = new SqlConnectionFactory("System.Data.SqlServer");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MyContextConfiguration>());
            using (var context = new MyContext())
            {
                var element = context.Dummies.FirstOrDefault();
            }
        }
    }
    internal class Dummy
    {
        public String Id { get; set; }
    }
    internal sealed class MyContext : DbContext
    {
        public MyContext() : base(@"Data Source=localhost;Initial Catalog=Dummies;User Id=<USER_ID>;Password=<PASSWORD>;MultipleActiveResultSets=False;")
        {
        }
        public DbSet<Dummy> Dummies { get; set; }
    }
    internal sealed class MyContextConfiguration : DbMigrationsConfiguration<MyContext>
    {
        public MyContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(MyContext context)
        {
            context.Dummies.AddOrUpdate(new Dummy() { Id = "First" });
        }
    }
