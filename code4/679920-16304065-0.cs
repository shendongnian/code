    using(OracleConnection conn = new OracleConnection())
    {
        using(DbTransaction transaction = conn.BeginTransaction())
        {
            try
            {
                // .... create a command 
                cmd1 = new OracleCommand({sql to get a value});
                cmd1.Transaction = transaction;
                cmd1.ExecuteScalar();
    
                // .... create another command 
                cmd1 = new OracleCommand({sql to update a value});
                cmd2.Transaction = transaction;
                cmd2.ExecuteNonQuery();
            
                transaction.Commit();  
            }
            catch (Exception err)
            {
                transaction.Rollback();
                throw err;   // or just throw; to preserve the deeper stack trace
            }
        }
    }
