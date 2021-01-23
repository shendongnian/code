            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("Select salt From niki where user_name = @username", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@username", username);
                    salt = cmd.ExecuteScalar() as string;
                }                
            }
