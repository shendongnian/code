    private static bool StoredProcedureExists(string sp)
    {    
    	  var connString = @"<your string here>";
          var query = string.Format("SELECT COUNT(0) FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = '{0}'", sp);
          using (var conn = new SqlConnection(connString))
          {
        	  conn.Open();
        	  using (var cmd = new SqlCommand(query, conn))
        	  {
                  return Convert.ToInt32(cmd.ExecuteScalar()) > 0;	
        	  }
          }
     }
