    public DataTable ExecuteQuery(Func<DataReader, DataTable> delegateMethod, string sqlQuery, SqlParameter param)
        {
            using (SqlConnection conn = new SqlConnection(this.MyConnectionString))
            {
                conn.Open();
    
                // Declare the parameter in the query string
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    // Now add the parameter to the parameter collection of the command specifying its type.
                    command.Parameters.Add(param);
    
                    command.Prepare();
    
                    // Now, add a value to it and later execute the command as usual.
                    command.Parameters[0].Value = dataId;
    
    
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                       return delegateMethod(dr);
                    }
                }
            }
        }
