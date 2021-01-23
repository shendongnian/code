    public interface IEntity
    {
        int Id { get; set; }
    }
    public abstract class GenericRepository<C, T> : IGenericRepository<T>
        where T : class, IEntity
        where C : DbContext, new()
    {
        public T GetByID(int id)
        {
            _entities.Set<T>().SingleOrDefault(x => x.Id == id);
        }
        ...
    }
