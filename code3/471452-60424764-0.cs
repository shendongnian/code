	public class MyTest : IDisposable
	{
		public IServiceProvider Services { get; private set; }
		public MyProjectOptions Options { get; private set; }
		public Logger Logger { get; private set; }
		private void Configure()
		{
			// appsettings.workspace.json for custom developer configuration
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.workspace.json", optional: true)
				.Build();
			Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.LiterateConsole()
				.WriteTo.RollingFile("logs/{Date}-log.txt")
				.CreateLogger();
			Options = configuration.GetSection("MyProject").Get<MyProjectOptions>();
			var services = new ServiceCollection();
			services.AddSingleton<ILogger>(s => Logger);
			// other DI logic and initializations ...
			//services.AddTransient(x => ...);
			Services = services.BuildServiceProvider();
		}
		public MyTest()
		{
			Configure();
			// ... initialize data in the test database ...
			var data = Services.GetService<TestDataService>();
			data.Clean();
			data.SeedData();
		}
		public void Dispose()
		{
			// ... clean-up data in the test database ...
			var data = Services.GetService<TestDataService>();
			data.Clean();
		}
	}
