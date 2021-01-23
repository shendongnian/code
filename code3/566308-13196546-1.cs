    string strQuery = "delete from [dbo].[myTable]";
    using (SqlConnection conn = new SqlConnection(strConn))
    {
      SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
      using (cmd = new SqlCommand(strQuery, conn))
      {
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         conn.Open();
         sqlCommand.Transaction = sqlTransaction;
         try
         {
             cmd.ExecuteNonQuery();                    //deleting database table data
             foreach (DataRow dr in ds.Tables[0].Rows) //Inserting new data into the Database table
             {
                 command = new SqlCommand(InsertQuery, conn);
                 command.ExecuteNonQuery();
             }
             sqlTransaction.Commit();
             conn.Close();
         }
         catch(Exception e)
         {
             sqlTransaction.Rollback();
             throw;
         }
      }
