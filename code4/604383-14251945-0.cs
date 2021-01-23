    List<String> Tablenames = new List<String>();
    
    using(SqlConnection connection = new SqlConnection("conn_string"))
    {
        string query = "show tables from YourDB";
        SqlCommand command = new SqlCommand(query, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Tablenames.Add(reader.GetString(0));
            }         
        }
    }
