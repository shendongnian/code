    public class ContextConfiguration : DbMigrationsConfiguration<Context>
       {
          public ContextConfiguration()
          {
             this.AutomaticMigrationsEnabled = true;
             this.AutomaticMigrationDataLossAllowed = true;
          }
       }
