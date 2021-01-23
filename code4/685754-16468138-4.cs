    public partial class YourDbContext : IDbContext
    {
         public IDbSet<T> EntitySet<T>() where T : class
         {
             return Set<T>();
         }
    }
