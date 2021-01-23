        string query = string.Format("SELECT Link FROM Linkovi");
        StringBuilder result = new StringBuilder();
        try
            {
                conn.Open();
                command.CommandText = query;
    
                SqlDataReader reader = command.ExecuteReader();
    
                while (reader.Read())
                {
                    result.Append(reader["Link"].ToString());
                }
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
            return result.ToString();
