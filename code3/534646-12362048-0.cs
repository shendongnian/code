    public class DbContext1 : DbContext
    {
        public DbContext1() : base("DbContext1")
        {
        }
        public DbSet<Table1> Object1 { get; set; }
    
        public DbSet<Table2> Object2 { get; set; }
    
        public DbSet<Table3> Object3 { get; set; }
    
        public DbSet<Table4> Object4 { get; set; }
    }
    public class DbContext2 : DbContext
    {
        public DbContext2() : base("DbContext2")
        {
        }
         
        public DbSet<Table1> Object5 { get; set; }
    }
