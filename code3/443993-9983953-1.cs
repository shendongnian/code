    public static bool IsAdmin(string iduser, string password)
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = @"
                SELECT IsAdmin 
                FROM [user] 
                WHERE iduser = @iduser AND mdp = @mdp;
            ";
            cmd.Parameters.AddWithValue("@iduser", iduser);
            cmd.Parameters.AddWithValue("@mdp", password);
            using (var reader = cmd.ExecuteReader())
            {
                return reader.Read() && reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
            }
        }
    }
