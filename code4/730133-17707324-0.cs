    var lstEmail = new List<string>();
    using (connection)
    {
        SqlCommand command = new SqlCommand("SELECT Email FROM TableName;",connection);                                                                        
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
           while (reader.Read())
           {
                lstEmail .add(reader.GetString(0))
           }
        }
        reader.Close();
    }
