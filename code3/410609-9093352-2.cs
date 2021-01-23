            using (var ts = new TransactionScope())
            {
                var db = new Db();
                var asd = from x in db.MyTable
                          where x.Id == 1
                          select x;
                asd.First().Name = "test2";
                db.SaveChanges();    // if you're here with the debugger the table is locked
            } 
            // and now its unlocked and you can do a select again
    internal class Db : DbContext
    {
        public Db()
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory();
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Db>());
            Database.Connection.ConnectionString =
                "yourconnectionstring;";
        }
        public DbSet<MyTable> MyTable { get; set; }
    }
    internal class MyTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MyTime { get; set; }
    }
