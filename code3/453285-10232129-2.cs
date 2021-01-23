    public interface IEventRepo
    {
        IEnumerable<Event> GetAll();
    }
    public interface ICacheProvider
    {
        bool IsDataCached();
        IEnumerable<Event> GetFromCache();
    }
    public class CacheProvider : ICacheProvider
    {
        public bool IsDataCached()
        {
            //do smth
        }
        public IEnumerable<Event> GetFromCache()
        {
            //get smth
        }
    }
    public class EventRepo : IEventRepo
    {
        private ICacheProvider _cacheProvider;
        public EventRepo(ICacheProvider cacheProvider)
        {
         _cacheProvider = cacheProvider
        }
        public IEnumerable<Event> GetAll()
        {
            if (_cacheProvider.IsDataCached())
            {
                return _cacheProvider.GetFromCache();
            }
            else
            {
                //get from repo, save data in cache etc
            }
        }
    }
    [TestClass]
    public class EventRepoTest
    {
        [TestMethod]
        public void GetsDataFromCacheIfDataIsCachedTest()
        {
            var cacheProvider = new Mock<ICacheProvider>(MockBehavior.Strict);
            cacheProvider
                .Setup(x => x.IsDataCached())
                .Returns(() =>
                {
                    return true;
                });
            cacheProvider
                .Setup(x => x.GetFromCache())
                .Returns(
                () => {
                return new Event[] { 
                    new Event() { Id = 1}, 
                    new Event() { Id = 2}
                    };
                }
                );
            var eventRepo = new EventRepo(cacheProvider.Object);
            var data = eventRepo.GetAll();
            cacheProvider.Verify(x => x.GetFromCache(), Times.Once());
        }
        [TestMethod]
        public void GetsDataFromDataBaseIfNotCachedTest()
        {
            var cacheProvider = new Mock<ICacheProvider>(MockBehavior.Strict);
            cacheProvider
                .Setup(x => x.IsDataCached())
                .Returns(() =>
                {
                    return false;
                });
            cacheProvider
                .Setup(x => x.GetFromCache())
                .Returns(
                () =>
                {
                    return new Event[] { 
                    new Event() { Id = 1}, 
                    new Event() { Id = 2}
                    };
                }
                );
            var eventRepo = new EventRepo(cacheProvider.Object);
            var data = eventRepo.GetAll();
            cacheProvider.Verify(x => x.GetFromCache(), Times.Never());
        }
    }
