        using (MySqlConnection connection = new MySqlConnection("Server=localhost; Database=sad - final project; Uid=root; Pwd=");
        using (MySqlCommand command = new MySqlCommand("SELECT password FROM employee WHERE ID = @UserId", connection)
        {
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserId", Input_ID); 
            
                var pwd = command.ExecuteScalar() as string;
            
            } 
            catch (Exception ex)
            {
                //do something
            }
        }
