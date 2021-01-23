    using (SqlConnection cnn = new SqlConnection(...))
    {
        using (SqlCommand cmd = new SqlCommand("...", cnn))
        {
            cnn.Open();
            using (SqlDataReader r = cmd.ExecuteReader())
            {
            }
        }
    }
