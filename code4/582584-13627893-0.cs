    public class MyAppContext : DbContext
    {
        public MyAppContext () : ;
        public DbSet<Table1> Table1{ get; set; }
        public DbSet<Table2> Table2 { get; set; }
        public DbSet<Table3> Table3 { get; set; }
        public DbSet<Table4> Table4 { get; set; }
        public DbSet<Table5> Table5 { get; set; }
    }
