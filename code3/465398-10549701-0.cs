    public class YourContext : DbContext
    {
      public YourContext()
        : base("YourConnectionString")
      {
        // Get the ObjectContext related to this DbContext
        var objectContext = (this as IObjectContextAdapter).ObjectContext;
        // Sets the command timeout for all the commands
        objectContext.CommandTimeout = 120;
      }
    }
