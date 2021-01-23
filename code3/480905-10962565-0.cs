    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        using (MySqlCommand command = new MySqlCommand ("SELECT * FROM emp where e_name =@Name", connection))
        {
            //
            // Add new SqlParameter to the command.
            //
            command.Parameters.Add(new MySqlParameter("Name", name));// name is get from console read line. 
             
            //
            // Read in the SELECT results.
            //
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // read each value 
            }
        }
    }
