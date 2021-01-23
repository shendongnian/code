    using System.Data;
    using System.Data.SqlClient;
    namespace DL.SO.Project.Web.UI
    {
        public class Startup
        {
            public IConfiguration Configuration { get; private set; }
            // ......
            public void ConfigureServices(IServiceCollection services)
            {
                // Read the connection string from appsettings.
                string dbConnectionString = this.Configuration.GetConnectionString("dbConnection1");
                
                // Inject IDbConnection, with implementation from SqlConnection class.
                services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
                // Register your regular repositories
                services.AddScoped<IDiameterRepository, DiameterRepository>();
                // ......
            }
        }
    }
