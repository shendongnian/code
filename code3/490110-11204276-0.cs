    try
    {
        // Encapsulate your data access code in this using
        using (TransactionScope scope = new TransactionScope())
        {
            .....
            scope.Completed();
        }
    }
        
