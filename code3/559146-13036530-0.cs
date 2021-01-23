    namespace eDirectory.Naive.Repository
    {
        /// <remarks>
        /// version 0.2 Chapter II: Repository
        /// </remarks>
        public class RepositoryLocatorEntityStore
            : RepositoryLocatorBase
        {
            protected Dictionary<Type, object> RepositoryMap = new Dictionary<Type, object>();
    
            public override IRepository<T> GetRepository<T>()
            {
                var type = typeof(T);
                if (RepositoryMap.Keys.Contains(type)) return RepositoryMap[type] as IRepository<T>;
                Type DIRepository = IoCContainer.getType()// get the right type from your mapping (IoC container)
                var repository = Activator.CreateInstance(DIRepository.MakeGenericType(type));
                RepositoryMap.Add(type, repository);
                return repository;
            }
        }
    }
