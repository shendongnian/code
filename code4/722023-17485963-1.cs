    // model
    public class CustomObject
    {
        public int Id { get; set; }
    }
    // interface
    public interface IRepository<T>
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
    public interface IRepositoryCacheManager<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        void Add(Expression<Func<T, bool>> expression, IEnumerable<T> result);
    }
    // cache manager
    public class RepositoryCacheManager<T> : IRepositoryCacheManager<T>
    {
        private Dictionary<Expression<Func<T, bool>>, IEnumerable<T>> cache;
        #region IRepositoryCache<T> Members
        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return cache[expression];
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> result = null;
            return cache.TryGetValue(expression, out result);
        }
        public void Add(Expression<Func<T, bool>> expression, IEnumerable<T> result)
        {
            cache.Add(expression, result);
        }
        #endregion
    }
    // cache repository decorator
    public class CachedRepositoryDecorator<T> : IRepository<T>
    {
        public CachedRepositoryDecorator(IRepositoryCacheManager<T> cache, IRepository<T> member)
        {
            this.member = member;
            this.cache = cache;
        }
        private IRepository<T> member;
        private IRepositoryCacheManager<T> cache;
        #region IRepository<T> Members
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            if (cache.Any(expression))
            {
                return cache.Get(expression);
            }
            else
            {
                IEnumerable<T> result = member.Find(expression);
                cache.Add(expression, result);
                return result;
            }
        }
        #endregion
    }
    // object repository
    public class CustomObjectRepository : IRepository<CustomObject>
    {
        #region IRepository<CustomObject> Members
        public IEnumerable<CustomObject> Find(Expression<Func<CustomObject, bool>> expression)
        {
            List<CustomObject> cust = new List<CustomObject>();
            // retrieve data here
            return cust;
        }
        #endregion
    }
    // example
    public class Consumer
    {
        // this cache manager should be persistent, maybe can be used in static, etc
        IRepositoryCacheManager<CustomObject> cache = new RepositoryCacheManager<CustomObject>();
        public Consumer()
        {
            IRepository<CustomObject> customObjectRepository = 
                new CachedRepositoryDecorator<CustomObject>(
                    cache
                    ,new CustomObjectRepository()
                    );
            customObjectRepository.Find(k => k.Id == 25);
        }
    }
