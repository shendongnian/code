    public class Repository<TEntity> where TEntity : class
    {
        private static readonly Dictionary<Type, Func<object>> specificRepositories =
            new Dictionary<Type, Func<object>>
            {
                { typeof(SpecificEntity), () => new SpecificRepository() }
            };
    
        protected Repository() {}
    
        public static Repository<T> Create<T>() where T : class
        {
            var entityType = typeof(T);
            if (specificRepositories.ContainsKey(entityType)) {
                return (Repository<T>)specificRepositories[entityType]();
            }
            else {
                return new Repository<T>();
            }
        }
    
        // default implementations omitted
    }
