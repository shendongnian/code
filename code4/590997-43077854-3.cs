    public int InsertWithQuery(string query, out string error)
    {
         error = "";
         int rowsInserted = 0;        
         if (error == "")
         {
              OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=)(PORT=)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=)));User Id=;Password="); 
              OracleTransaction trans = con.BeginTransaction();              
              try
              {
                  error = "";
                  OracleCommand cmd = new OracleCommand();
                  cmd.Transaction = trans;
                  cmd.Connection = con;
                  cmd.CommandText = query;
                  rowsInserted = cmd.ExecuteNonQuery();
                  trans.Commit();
                  con.Dispose();
                  return rowsInserted;
              }
              catch (Exception ex)
              {
                  trans.Rollback();
                  error = ex.Message;
                  rowsInserted = 0;
              }
              finally
              {
                  con.Dispose();
              }
         }
         return rowsInserted;
    }
