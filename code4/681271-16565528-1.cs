    public interface IEntityWithId
    {
      string Id { get; }
    }
    
    public static object FastFind<TEntity>(this DbSet<TEntity> dbSet, string id)
      where TEntity : IEntityWithId, class
    {
      // First see if the DbSet already has it in the local cache
      TEntity entity = dbSet.Local.SingleOrDefault(x => x.Id == id);
      // Then query the database
      return entity ?? dbSet.SingleOrDefault(x => x.Id == id);
    }      
