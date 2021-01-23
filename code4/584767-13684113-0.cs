            using(connection = new MySqlConnection(GetConnectionString())
            {
                connection.Open();
                using(MySqlCommand command = connection.CreateCommand();
                {
                    //for testing
                    string sql = "UPDATE `tb_gast` SET FIRSTNAME='test' WHERE ID=270";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
