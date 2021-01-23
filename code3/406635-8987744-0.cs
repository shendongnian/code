        protected  ISession Session
        {
            get
            {
                return NHibernateSessionFactory.CurrentFor(dataBaseFactoryKey);
            }
        }
