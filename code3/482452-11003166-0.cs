    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new NHibernate.Cfg.Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(NHibernateHelper).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        private static ISession _persistentSession = null;
        public static ISession GetPersistentSession()
        {
            if (_persistentSession == null)
            {
                _persistentSession = SessionFactory.OpenSession();
            }
            return _persistentSession;
        }
    }
