    public static DbContextExtensions
    {
      public static IQueryable<T> GetActive<T>(this DbContext context) 
        where T : class, IConcurrent
      {
         return context.Set<T>().Where(e => e.IsActive);
      }
    }
