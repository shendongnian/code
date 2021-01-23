        System.Transactions
        
        using(TransactionScope transaction = new TransactionScope())
        {
            try
            {
                //modify your database here
            
                transaction.Complete();
            }
            catch(Exception)
            {
                transaction.Dispose();
            }
        }
