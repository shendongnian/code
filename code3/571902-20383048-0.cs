    public class YouSessionFactory : INHibernateSessionFactory, IDisposable
    {
        private ISessionFactory _sessionFactory;
        //codes for initial _sessionFactory, for configuration,mapping or something else.
        //balalalalalala
        //....
        
        public ISessionFactory BuildSessionFactory()
        {
            return _sessionFactory;
        }
        public void Dispose()
        {
            if (!_sessionFactory.IsClosed || _sessionFactory != null)
            {
                _sessionFactory.Close();
                _sessionFactory.Dispose();
            }
        }
    }
