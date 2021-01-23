    public class PrivatePropertiesContext : DbContext {
      public DbSet<Person> People {
        get;
        set;
      }
    }
