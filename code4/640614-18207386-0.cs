    public partial class Entities : ObjectContext
    {
        #region Constructors
               
        public static string getConStrSQL(string UID,string PWD)
        {
            
            string connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder
            {
                Metadata = "res://*",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    InitialCatalog = "your_database_name",
                    DataSource = "your_server",
                    IntegratedSecurity = false,
                    UserID = UID,                
                    Password = PWD,              
                }.ConnectionString
            }.ConnectionString;
            return connectionString;
        }
        
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string UID,string PWD)
            : base(getConStrSQL(UID,PWD), "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
        ......
