        using (MySqlConnection connection = new MySqlConnection("Server=localhost; Database=sad - final project; Uid=root; Pwd=");
        using (MySqlCommand command = new MySqlCommand("SELECT password FROM employee WHERE ID = @UserId", connection)
        {
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserId", Input_ID); 
            
                var pwd = command.ExecuteScalar() as string;
                //Do something with the stored password.
                //Consider encryption and other security concerns when working with passwords.
            } 
            catch (Exception ex)
            {
                //handle your exceptions
            }
        }
