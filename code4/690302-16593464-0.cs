        try
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions(){IsolationLevel = IsolationLevel.ReadCommitted}))
            try
            {
                CallYourDataAccessMethodsHere();
                scope.Complete();
            }
            catch (Exception ex)
            {
                //Handle or log the error during the transaction
            }
        }
        catch (Exception ex)
        {
            //This will catch a TransactionAbortedException and hopefully help track down the problem
        }
   
        
        
