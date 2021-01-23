    using (TransactionScope scope = new TransactionScope())
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            { 
                // Do all work here...  
            }
            catch (Exception ex)
            {
               // Delete files
               // LogError(ex);
            }                   
        }
        scope.Complete();
    }
