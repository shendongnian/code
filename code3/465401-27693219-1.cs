    public static class DbContextExtensions
    {
       public static void SetCommandTimeout(this ObjectContext dbContext,
           int TimeOut)
       {
           dbContext.CommandTimeout = TimeOut;
       }
    }
