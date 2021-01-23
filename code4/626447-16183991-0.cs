    private static string DisplayTest(string searchValue)
    {
        string connectionString = "Data Source=.;Initial Catalog=LibraryReservationSystem;Integrated Security=True;Connect Timeout=30";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string commandText = @"SELECT AccountType,* FROM Account WHERE AccountType LIKE @input";
    
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
    
                command.Parameters.Add("@input", SqlDbType.NVarChar);
                command.Parameters["@input"].Value = string.Format("%{0}%", searchValue);
    
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }
            }
        }
    
        return String.Empty;
    }
