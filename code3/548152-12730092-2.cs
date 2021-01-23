    public T GetScalarValue<T>(string sql)
    {
        T result = default(T);
    
        try
        {
            using (SqlConnection conn = new SqlConnection("MY_SQL_SERVER_CONNECTION_STRING"))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                
                var scalar = cmd.ExecuteScalar();
    
                if (scalar != null)
                {
                    result = (T)scalar; 
                }
            }
    
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
    }
