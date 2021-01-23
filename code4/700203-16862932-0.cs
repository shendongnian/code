    using (OleDbConnection conn = /* Create new instance using your favorite method */)
    {
        conn.Open();
        using (OleDbCommand command = /* Create new instance using your favorite method */)
        {
            // Do work
        }
        conn.Close(); // Optional
    }
