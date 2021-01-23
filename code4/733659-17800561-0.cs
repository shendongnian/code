        string connectionString = "Persist Security Info=False;database=qwertyui;server=qwertyuiop.com;Uid=asdfghj;Pwd=qazwsxedc;port=3306";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "INSERT INTO table VALUES (@parameter)";
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@parameter", parameter);
                cmd.ExecuteNonQuery();
            }
        }
