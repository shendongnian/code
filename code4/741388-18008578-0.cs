    public string InsertBrand()
            {
                try
                {
                   
                    using (TransactionScope transaction = new TransactionScope())
                    {
                       
                       //Do your operations here
                        transaction.Complete();
                        return "Mobile Brand Added";
    
                    }
                }
                catch (Exception ex)
                {
    
                    throw ex;
                }
            }
