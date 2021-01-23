      public class DapperWrapper : IDapperWrapper
      {
    	public IEnumerable<T> Query<T>(string query, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    	{
    	  using (var conn = Db.NewConnection())
    	  {
    		  var results = conn.Query<T>(query, param, transaction, buffered, commandTimeout, commandType);
    		  // Do whatever you want with the results here
    		  // Such as Security, Logging, Etc.
    		  return results;
    	  }
    	}
      }
