    interface IRepository : IGetById, IGetAll, ISave, IDelete { }
    class Repository : IRepository
    {
        private readonly IGetById getter;
        private readonly IGetAll allGetter;
        private readonly ISave saver;
        private readonly IDelete deleter;
        public Repository(IGetById getter, IGetAll allGetter, ISave saver, IDelete deleter)
        {
            this.getter = getter;
            this.allGetter = allGetter;
            this.saver = saver;
            this.deleter = deleter;
        }
        public T GetById<T>(object id)
        {
            return getter.GetById<T>(id);
        }
        public IEnumerable<T> GetAll<T>()
        {
            return allGetter.GetAll<T>();
        }
        public void Save<T>(T item) where T : IHasId
        {
            saver.Save(item);
        }
        public void Delete<T>(object id)
        {
            deleter.Delete<T>(id);
        }
    }
