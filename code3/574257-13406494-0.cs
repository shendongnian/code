    public interface IFactory<T>
    {
        IRepository<T> Create(ISession session);
    }
    
    public class RepositoryFactory<T> : IFactory<T> where T : new()
    {
        public IRepository<T> Create(ISession session)
        {
            return new IRepository<T>();
        }
    }
