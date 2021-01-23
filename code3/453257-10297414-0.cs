	class Program
	{
		private const string ConnectionString = @"Data Source=c:\subsonic.db";
		private const string ProviderString = @"System.Data.SQLite";
		private static IDataProvider provider = ProviderFactory.GetProvider(ConnectionString, ProviderString);
		private static SimpleRepository repo = new SimpleRepository(provider, SimpleRepositoryOptions.RunMigrations);
		static void Main(string[] args)
		{
			var demo = new Demo { Name = "Test Demo", LaunchDate = DateTime.Now };
			repo.Add(demo);
		}
		class Demo
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public DateTime LaunchDate { get; set; }
		}
	}
