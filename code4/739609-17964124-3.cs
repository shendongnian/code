    SqlCommand CreateSqlCommand(string sql, SqlParameterCollection parameters)
    {              
        SqlCommand cmd = _conn.CreateCommand();
        cmd.Connection = _conn;                
               
        cmd.CommandText = sql;
    
        if (parameters != null)
            foreach (SqlParameter param in parameters)
                        cmd.Parameters.Add(param); 
        return cmd;
    }
    DataTable ExecuteDataTableQuery(SqlCommand cmd)
    {            
        DataTable table = null;
    
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            table = new DataTable();
            try
            {    
                 adapter.Fill(table);    
            }
            catch (SqlException sqlEx)
            {
                rethrow;
            }    
        }    
        return table;
    }
