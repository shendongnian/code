    public class DataStore<TEntity> : IDataStore<TEntity> where TEntity : class, IDto
    {
      private readonly List<TEntity> m_dtos = new List<TEntity>();
      ...
      public void Delete(Func<TEntity, bool> predicate)
      {
        var toDelete = m_dtos.FirstOrDefault(predicate);
        m_dtos.Remove(toDelete);
      }
    }
