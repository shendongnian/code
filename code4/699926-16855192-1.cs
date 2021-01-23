    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        // execute a single SELECT here
    } // <==== end the first connection
    using (TransactionScope scope = new TransactionScope())
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        for (int i=0; i<...; i++)
        {
            Update(connection); // UPDATE query
        }
        scope.Complete();
    }
