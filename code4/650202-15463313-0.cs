    public int Update(int id)
    {
        string connectionString = "... put the connection string to your db here ...";
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "UPDATE docs SET locked = 0 WHERE ID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
    }
