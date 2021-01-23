            connection = new MySqlConnection();
            try
            {
               string sql = "UPDATE tb_gast SET FIRSTNAME='test' WHERE ID=270";
               MySqlCommand command = new MySqlCommand(sql, connection);
               connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
        }
