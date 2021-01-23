    using (TransactionScope scope = new TransactionScope())
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Do all work here...                    
        }
        scope.Complete();
    }
