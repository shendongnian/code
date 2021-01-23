     private void SomeMethod()
     {
        SqlCommand sqlcmd = new SqlCommand();
        using (SqlConnection sqlConn = new SqlConnection(ConfigurationSettings.AppSettings["strConnectionString"]))//strConnectionString
        {
           sqlConn.Open();
           sqlcmd.Connection = sqlConn;
           SqlTransaction transaction;
           // Start a local transaction.
           transaction = sqlConn.BeginTransaction("DeleteRecs");
           sqlcmd.Transaction = transaction;
           sqlcmd.CommandTimeout = 60;
           sqlcmd.CommandText = "uf_DeleteWeeks";
           sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
           try
           {
              sqlcmd.ExecuteNonQuery();
              sqlcmd.Transaction.Commit();
           }
           catch (SqlException sqle)
           {
            
            try
            {
               transaction.Rollback("DeleteRecs");
            }
            catch (Exception ex)
            {
                                
            }
           Console.WriteLine(sqle.Message);
           }
          }
          ((IDisposable)sqlcmd).Dispose();
       }
