    public class YourContext : DbContext
        {
    
           // your DBSets and contructors, etc
    
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new UserConfiguration());            
                base.OnModelCreating(modelBuilder);
            }
    
    
        }
