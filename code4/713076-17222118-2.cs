    public class MyApiContext : DbContext
    {
            
        ...
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MyApiKeyMapping());
            modelBuilder.Configurations.Add(new AccountEntryMapping());
        }
    }
