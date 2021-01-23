    public class DapperConnection
    {
        public IDbConnection DapperCon {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                
            }
        }
    }
