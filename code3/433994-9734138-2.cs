    public class Repository<T> : IRepository<T>
    {
        private readonly ISessionFactory SessionFactory;
        public Repository(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }
        public ISession Session
        {
            get
            {
                return SessionFactory.GetCurrentSession();
            }
        }
        public T Get(long id)
        {
            return Session.Get<T>(id);
        }
    }
