        public class NHibernateSessionFactory
        {
            private ISessionFactory sessionFactory;
    
            private readonly string ConnectionString = "";
            private readonly string nHibernateConfigFile = "";
    
            public NHibernateSessionFactory(String connectionString, string nHConfigFile)
            {
                this.ConnectionString = connectionString;
                this.nHibernateConfigFile = nHConfigFile;
            }
    
            public ISessionFactory SessionFactory
            {
                get { return sessionFactory ?? (sessionFactory = CreateSessionFactory()); }
            }
    
            private ISessionFactory CreateSessionFactory()
            {
                Configuration cfg;
                cfg = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.nHibernateConfigFile));
    
                // With this row below Nhibernate searches for the connection string inside the App.Config.
                // cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionStringName, System.Environment.MachineName);
                cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionString, this.ConnectionString);
    
    #if DEBUG
                cfg.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, "true");
                cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
    #endif
    
                return (cfg.BuildSessionFactory());
            }
        }
