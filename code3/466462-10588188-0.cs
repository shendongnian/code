    public class MySessionFactoryBuilder : IMySessionFactoryBuilder
    {
        private FluentConfiguration _fluentConfiguration = null;
        public MySessionFactoryBuilder()
        {
        }
        void Initialize(string connectionStringKey)
        {
            IPersistenceConfigurer persistenceConfigurer = null;
            persistenceConfigurer = MsSqlConfiguration.MsSql2008
                    .UseOuterJoin()
                    .ConnectionString(connectionStringKey)
                    .FormatSql()
                    .ShowSql()
                    ;
            _fluentConfiguration = Fluently.Configure()
                .Database(persistenceConfigurer)
                .ExposeConfiguration(ConfigurePersistence)
                .ProxyFactoryFactory(typeof(ProxyFactoryFactory))
                .BuildConfiguration()
                ;
        }
        public ISessionFactory BuildSessionFactory(string connectionStringKey)
        {
            Initialize(connectionStringKey);
            return _fluentConfiguration.BuildSessionFactory();
        }
    }
