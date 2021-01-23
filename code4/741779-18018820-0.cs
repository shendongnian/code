    using(SqlCeConnection sqlCeConnection = new SqlCeConnection(Properties.Settings.Default.DatabaseConnectionString)) {
        using(SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT * FROM users WHERE id = @id", sqlConnection)) {
            sqlCeCommand.CommandType = CommandType.Text;
            sqlCeCommand.Parameters.AddWithValue("@id", 1);
            try {
                sqlCeConnection.Open();
                SqlCeDataReader reader = sqlCeCommand.ExecuteReader(CommandBehavior.SingleRow);
                if(reader.Read()) {
                    System.Console.WriteLine(reader);
                    System.Console.WriteLine(reader["id"]);
                    System.Console.WriteLine(reader["name"]);
                }
            }
            catch(Exception e) {
                System.Console.WriteLine(e.GetBaseException());
            }
            finally {
                sqlCeConnection.Close();
            }
        }
    }
