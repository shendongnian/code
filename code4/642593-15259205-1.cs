    using (var conn = new SqlConnection(connectionString))
    {
        using (var comm = conn.CreateCommand())
        {
            conn.Open();
            comm.CommandText = "SOME SQL HERE";
            // command type, parameters, etc.
            //pick one of the following
            comm.ExecuteNonQuery();
            int value = (int)comm.ExecuteScalar();
            SqlDataReader reader = comm.ExecuteReader();
        }
    }
