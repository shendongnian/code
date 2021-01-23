    public class YourContext : DbContext
    {
      public YourContext(string targetDatabase)
      {
          this.Database.Connection.ChangeDatabase(targetDatabase);
      }
    }
    
