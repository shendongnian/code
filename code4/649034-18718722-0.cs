     Follow below code,Here i am calling two storedprocedures in one transaction(like this you can try for multiple storedprocedures)  
  
    string cnnString =WebConfigurationManager.ConnectionStrings["MyString"].ConnectionString;
         SqlConnection cnn = new SqlConnection(cnnString);
         SqlTransaction transaction;
        
                cnn.Open();
                transaction = cnn.BeginTransaction();
        
                try
                {
        
                    // Command Objects for the transaction
                    SqlCommand cmd1 = new SqlCommand("sproc1", cnn);
                    SqlCommand cmd2 = new SqlCommand("sproc2", cnn);
        
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    
                    cmd1.Parameters.Add(new SqlParameter("@Param1", SqlDbType.NVarChar, 50));
                    cmd1.Parameters["@Param1"].Value = paramValue1;
        
                    cmd1.Parameters.Add(new SqlParameter("@Param2", SqlDbType.NVarChar, 50));
                    cmd1.Parameters["@Param2"].Value = paramValue2;
        
                    cmd2.Parameters.Add(new SqlParameter("@Param3", SqlDbType.NVarChar, 50));
                    cmd2.Parameters["@Param3"].Value = paramValue3;
        
                    cmd2.Parameters.Add(new SqlParameter("@Param4", SqlDbType.NVarChar, 50));
                    cmd2.Parameters["@Param4"].Value = paramValue4;
        
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
        
                     transaction.Commit();
                }
        
                catch (SqlException sqlEx)
                {
                    transaction.Rollback();
                }
        
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
    Regards
    Chandu
