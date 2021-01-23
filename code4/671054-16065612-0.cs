    public class SqlCeFactory
    {
        public SqlCeConnection OpenConnection()
        {
            var conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["Test"].ToString());
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
