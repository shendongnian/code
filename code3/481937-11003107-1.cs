	public static class DatabaseContextFactory
	{
		static ISessionFactory _sessionFactory;
		static Configuration _configuration;
		public static ISessionFactory CreateSessionFactory()
		{
			if (_sessionFactory == null)
			{
				_sessionFactory = Fluently.Configure()
					.Database(MsSqlConfiguration.MsSql2008.ConnectionString(cs => cs.FromConnectionStringWithKey("SurrogateExample")))
					.ExposeConfiguration(c => _configuration = c)
					.Mappings(cfg => cfg.HbmMappings.AddFromAssemblyOf<Program>())
					.BuildSessionFactory();
			}
			return _sessionFactory;
		}
		public static void CreateSchema()
		{
			CreateSessionFactory();
			new SchemaExport(_configuration).Execute(false, true, false);
		}
	}
