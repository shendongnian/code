        public static ISessionFactory CreateSessionFactory()
        {
            string conStringName = "ConnectionString";
            // http://weblogs.asp.net/ricardoperes/archive/2010/03/31/speeding-up-nhibernate-startup-time.aspx
            System.Runtime.Serialization.IFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            NHibernate.Cfg.Configuration cfg = null;
            if (File.Exists("Configuration.serialized"))
            {
                using (Stream stream = File.OpenRead("Configuration.serialized"))
                {
                    cfg = serializer.Deserialize(stream) as Configuration;
                }
            }
            else
            {
                // file not exists, configure normally, and serialize NH configuration to disk
                cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(conStringName)))
                    .Mappings(m => m.FluentMappings.Add<Entity1>())
                    .Mappings(m => m.FluentMappings.Add<Entity2>())
                    .Mappings(m => m.FluentMappings.Add<Entity3>())
                    .ExposeConfiguration(p => p.SetProperty("current_session_context_class", "web"))
                    .BuildConfiguration();
                using (Stream stream = File.OpenWrite("Configuration.serialized"))
                {
                    serializer.Serialize(stream, cfg);
                }
            }
            
            return cfg.BuildSessionFactory();
        }
