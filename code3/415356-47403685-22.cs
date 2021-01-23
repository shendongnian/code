    namespace DL.SO.Project.Web.UI
    {
        public class Startup
        {
            // ......
             
            public void ConfigureServices(IServiceCollection services)
            {
                var connectionDict = new Dictionary<DatabaseConnectionName, string>
                {
                    { DatabaseConnectionName.Connection1, this.Configuration.GetConnectionString("dbConnection1") },
                    { DatabaseConnectionName.Connection2, this.Configuration.GetConnectionString("dbConnection2") }
                };
                // Inject this dict
                services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);
                // Inject the factory
                services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
                // Register your regular repositories
                services.AddScoped<IDiameterRepository, DiameterRepository>();
                // ......
            }
        }
    }
