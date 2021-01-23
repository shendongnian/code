    public class Database1
    {
        private ISessionFactory _sessionFactory;
        public Database1SessionFactory()
        {
            //Build your session factory for Database1 here
            //with the entity C_SM_SEND, connection string to Database1, etc, etc.
        }
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
    public class Database2
    {
        private ISessionFactory _sessionFactory;
        public Database1SessionFactory()
        {
            //Build your session factory for Database2 here
            //with the entity PC_TO_SM_PRIM_DATA, connection string to Database2, etc, etc.
        }
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
