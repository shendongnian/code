    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        DataContext _db;
        public Repository()
        {
            _db = new DataContext("Database Connectionstring");
            _db.DeferredLoadingEnabled = false;
        }
        System.Data.Linq.Table<T> GetTable
        {
            get { return _db.GetTable<T>(); }
        }
        public IEnumerable<T> GetAll(Func<T, bool> exp)
        {
            return GetTable.Where<T>(exp);
        }
        ...
        .
    }
