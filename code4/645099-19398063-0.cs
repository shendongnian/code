    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Loads the configuration:
            modelBuilder.Configurations.Add(new MyMyDataClassConfiguration()); 
        }
        // ...
    }
    public class MyDataClassConfiguration : EntityTypeConfiguration<MyDataClass>
    {
        public MyDataClassConfiguration()
        {
            ToTable("MyDataTableName"); // Maps to table
            // Specify composite key (I was missing a key here)
            HasKey(data => new {data.First_Key_Name, data.Second_Key_Name });
        }
    }
