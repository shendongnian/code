    public static string GetLinks()
    {
        string query = string.Format("SELECT Link FROM Linkovi");
        try
        {
            conn.Open();
            command.CommandText = query;
            List<string> links = new List<string>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    links.Add(reader["Link"].ToString());
                }
            }
        }
        finally
        {
            conn.Close();
        }
        return string.Join(",", links); // You can change the delimiter here to something else.
    }
