    public interface IDataStore
    {
        IQueryable<T> Query<T>();
    }
    public class NHibernateDataStore : IDataStore
    {
        private readonly ISession _session;
        public NHibernateDataStore(ISession session)
        {
            _session = session;
        }
        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
    }
