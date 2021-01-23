    public class DatabaseProvider {
        private readonly IDbConnection _cn;
    
        public DatabaseProvider(IDbConnection cn) {
            _cn = cn;
        }
    
        public void ExecuteNonQuery(string query) {
    
    		using(SqliteCommand cmd = new SqliteCommand{ Connection = _cn})
    		{
    			try
    			{
    			   _cn.Open();
    			}
    			catch
    			{
    			   // Message Connection Error
    			}
    			
    			try
    			{
    			   cmd.CommandText = query;
    			   cmd.ExecuteNonQuery();
    			}
    			catch
    			{
    				// Message Query Error
    			}
    			finally
    			{
    				_cn.Close();  // Connection close
    			}
    
    		}
    
    
        }
    }
