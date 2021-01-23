    public class CDBContext : DbContext    
    {
        public DbSet<tbl1> tbl1{ get; set; }
        public DbSet<tbl2> tbl2{ get; set; }
        public DbSet<tbl3> tbl3{ get; set; }
        public DbSet<tbl4> tbl4{ get; set; }
    }
