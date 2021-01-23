    using System.Configuration;
    class DB_Handler
    {
            string connectionString=string.Empty;
            public DB_Handler(string databaseName)
            {
               this.connectionString = ConfigurationManager.ConnectionStrings["DbConnnectionString"].ConnectionString.Replace ("{MyDatabasePlaceHolder}", databaseName)
            }
            
            public GetData()  
            {
              // Make use of this.connectionString to fetch data
            }
    }
