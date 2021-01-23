    class RepositoryStore
    {
        private IDictionary<Type, Lazy<object>> Repositories { get; set; }
    
        public RepositoryStore()
        {
            this.Repositories = new Dictionary<Type, Lazy<object>>();
        }
    
        public RepositoryStore Add<T, TRepo>() where TRepo : Repository<T>
        {
            this.Repositories[typeof(T)] = new Lazy<object>(() => Activator.CreateInstance(typeof(TRepo)));
            return this;
        }
    
        public Repository<T> GetRepository<T>()
        {
            if (this.Repositories.ContainsKey(typeof(T)))
            {
                return this.Repositories[typeof(T)].Value as Repository<T>;
            }
    
            throw new KeyNotFoundException("Unable to find repository for type: " + typeof(T).Name);
        }
    }
