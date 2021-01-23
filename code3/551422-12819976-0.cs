    public class DatabaseProvider {
        private readonly IDbConnection _cn;
    
        public DatabaseProvider(IDbConnection cn) {
            _cn = cn;
        }
    
        public void ExecuteNonQuery(string query) {
            // Execute the query
            try{
               _cn.Open();
               var cmd = _cn.CreateCommand();
               cmd.CommandText = query;
               cmd.ExecuteNonQuery();
            }
            catch(ExpectedExceptions){
               //take care of business
            }
            finally{
                _cn.Close();
            }
    
        }
    }
