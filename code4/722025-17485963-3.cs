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
    public interface ICacheableRepository<T>
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, Func<int> cacheKey);
    }
    public interface IRepositoryCacheManager<T>
    {
        IEnumerable<T> Get(int key);
        bool Any(int key);
        void Add(int key, IEnumerable<T> result);
    }
    // cache manager
    public class RepositoryCacheManager<T> : IRepositoryCacheManager<T>
    {
        private Dictionary<int, IEnumerable<T>> cache = new Dictionary<int,IEnumerable<T>>();
        #region IRepositoryCache<T> Members
        public IEnumerable<T> Get(int key)
        {
            return cache[key];
        }
        public bool Any(int key)
        {
            IEnumerable<T> result = null;
            return cache.TryGetValue(key, out result);
        }
        public void Add(int key, IEnumerable<T> result)
        {
            cache.Add(key, result);
        }
        #endregion
    }
    // cache repository decorator
    public class CachedRepositoryDecorator<T> : IRepository<T>, ICacheableRepository<T>
    {
        public CachedRepositoryDecorator(IRepositoryCacheManager<T> cache
            , IRepository<T> member)
        {
            this.member = member;
            this.cache = cache;
        }
        private IRepository<T> member;
        private IRepositoryCacheManager<T> cache;
        #region IRepository<T> Members
        // this is not caching
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return member.Find(expression);
        }
        #endregion
        #region ICacheableRepository<T> Members
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression, Func<int> cacheKey)
        {
            if (cache.Any(cacheKey()))
            {
                return cache.Get(cacheKey());
            }
            else
            {
                IEnumerable<T> result = member.Find(expression);
                cache.Add(cacheKey(), result);
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
            int id = 25;
            ICacheableRepository<CustomObject> customObjectRepository =
                new CachedRepositoryDecorator<CustomObject>(
                    cache
                    , new CustomObjectRepository()
                    );
            customObjectRepository.Find(k => k.Id == id, () => { return id; });
        }
    }
