    using (SqlConnection conn = new SqlConnection(...))
    {
        using(SqlCommand cmd = new SqlCommand(..., conn))
        {
            conn.Open();
            using(DataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
            {
                 ...
            {
        }
    }
