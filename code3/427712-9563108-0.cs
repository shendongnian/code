    public class MyContext
    {
        private string schemaName = "Foo";
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<MyEntity>().ToTable("MyTable", schemaName);
        } 
    }
