        private static void Configure(NHibernate.Cfg.Configuration cfg)
        {
            cfg.EventListeners.SaveOrUpdateEventListeners = new NHibernate.Event.ISaveOrUpdateEventListener[] {new SaveListener()};
        }
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().Database(...).
                        .Mappings(...)
                        .ExposeConfiguration(Configure)                       
                        .BuildSessionFactory();
        }
