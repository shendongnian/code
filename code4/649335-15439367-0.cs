    public static List<string> GetLinks()
    {
        string query = string.Format("SELECT Link FROM Linkovi");
        List<string> result = new List<string>();
        try {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                result.Add(reader["Link"].ToString());
            }
            reader.Close();
        } finally {
            conn.Close();
        }
        return result;
    }
