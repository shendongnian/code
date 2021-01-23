    using (SqlCeConnection sqlConnection = new SqlCeConnection(Properties.Settings.Default.DatabaseConnectionString))
    {
        using (SqlCeCommand sqlCommand = new SqlCeCommand("SELECT * FROM users WHERE id = @id", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", 1);
            try
            {
                sqlConnection.Open();
                SqlCeDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    System.Console.WriteLine(reader);
                    System.Console.WriteLine(reader["id"]);
                    System.Console.WriteLine(reader["name"]);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.GetBaseException());
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
