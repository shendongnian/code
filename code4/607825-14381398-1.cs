    using (var conn = new SqlConnection(CONNECTION_STRING))
    {
        using (var cmd = conn.CreateCommand())
        {
            String SQL = "SELECT * FROM MILLIONS_RECORDS_TABLE";
            String SQLOrderBy = "ORDER BY DATE ASC "; //GetOrderByClause(Object someInputParams);
            String limitedSQL = GetPaginatedSQL(0, 50, SQL, SQLOrderBy);
    
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
    
            cmd.CommandText = limitedSQL;
    
            // Add named parameters here to the command if needed...
    
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
    
            // Process the dataset...
        }
        conn.Close();
    }
