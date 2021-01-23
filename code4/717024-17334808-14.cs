    public static void UpdateImage(int id, byte[] imgdata)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Images SET ImageData = @p1 WHERE ID = @p2", conn))
            {
                cmd.Parameters.AddWithValue("@p1", imgdata);
                cmd.Parameters.AddWithValue("@p2", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
