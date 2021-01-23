    try
        {            
            using (TransactionScope scope = new TransactionScope())
            {
                //// create the connection
                using (SqlConnection connection1 = new SqlConnection(connectString1))
                {
                    //// open the connection
                    connection1.Open();
    
                    foreach(string lst in str[])
                    {
                         //insert query
                         connection1.ExecSqlNonQuery("sp_tbltest", CommandType.StoredProcedure);
                    }                    
                }
    
                scope.Complete();
    
            }
    
        }
        catch (Exception)
        {
            scope.Rollback();
        }
