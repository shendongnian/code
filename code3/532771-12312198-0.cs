    public interface IRepository<T>
    {
      IQuerable<T> GetEntities();
    }
    
    // this works with database
    public class SomeEntityDbRepository<SomeEntity> : IRepository<SomeEntity>
    {
      // ...
      public IQuerable<SomeEntity> GetEntities()
      {
        return dbContext.Set<SomeEntity>();
      }
    }
    // this works with file storage:
    public class SomeEntityFileRepository<SomeEntity> : IRepository<SomeEntity>
    {
      // ...
      public IQuerable<SomeEntity> GetEntities()
      {
        using (var stream = new Filestream(/* ... */))
        {
          var serializer = /* ... */;
          var someEntities = /* ...deserialize from file */
           
          return someEntities.AsQuerable();
        }
      }
    }
