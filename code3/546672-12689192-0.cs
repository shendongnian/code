    public void processQuery(string query, Action<MySqlDataReader> fn)
    {
        MySqlDataReader reader;
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var cmd = new MySqlCommand(query, connection))
            {
                reader = cmd.ExecuteReader();
                fn(reader);
            }
        }
    }
    // caller
    String sql = "SELECT * FROM `table`";
    objDB.procesQuery(sql, dr => {
        if (dr.Read())
        {
           // some code goes hear
        } 
    });
