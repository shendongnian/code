    using(TransactionScope outerScope = new TransactionScope())
    {
        // Execute query 1
     
        using(TransactionScope innerScope = new TransactionScope())
        {
            try
            {
                // Execute query 2
            }
            catch (Exception)
            {
            }
     
            innerScope.Complete();
        }
     
        outerScope.Complete();
    }
