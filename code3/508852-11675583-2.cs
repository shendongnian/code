    using (SqlConnection connection = new SqlConnection())
    {
        connection.Open();
        using (SqlTransaction transaction = connection.BeginTransaction())
        {
            transaction.Commit();
        }
    }
