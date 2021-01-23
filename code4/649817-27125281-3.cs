    class InMemoryStore : IRepository
    {
        private readonly IDictionary<Type, Dictionary<object, object>> db;
        public InMemoryStore(IDictionary<Type, Dictionary<object, object>> db)
        {
            this.db = db;
        }
        
        ...
    }
