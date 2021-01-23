    using (SqlConnection c = new SqlConnection(connString))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Person WHERE PersonID = @PersonID", c))
        {
            cmd.Parameters.AddWithValue("@PersonID", personId);
            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                }
            }
        }
    }
