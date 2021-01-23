    public class RepositoryStore
    {
        private IDictionary<Type, object> Repositories { get; set; }
    
        public RepositoryStore()
        {
            this.Repositories = new Dictionary<Type, object>();
        }
    
        public RepositoryStore SetRepository<T>(Repository<T> repo)
        {
            this.Repositories[typeof(T)] = repo;
            return this;
        }
    
        public Repository<T> GetRepository<T>()
        {
            if (this.Repositories.ContainsKey(typeof(T)))
            {
                return this.Repositories[typeof(T)] as Repository<T>;
            }
    
            throw new KeyNotFoundException("Unable to find repository for type: " + typeof(T).Name);
        }
    }
