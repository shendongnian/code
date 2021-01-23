    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        // execute a single SELECT here
    } // <==== end the first connection
    using (TransactionScope scope = new TransactionScope())
    {
        for (int i=0; i<...; i++)
        {
            Update(); // UPDATE query
        }
        scope.Complete();
    }
