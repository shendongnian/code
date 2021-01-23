    public abstract class SalesDb : IDisposable
    {
        protected static IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NAME"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
