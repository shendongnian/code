    public class Repository<T> where T : class, IAggregateRoot
    {
        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            ObjectSet.AddObject(entity);
        }
    }
