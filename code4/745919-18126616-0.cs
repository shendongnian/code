        try
        {
            using(TransactionScope ts = new TransactionScope())
            {
                //perform SQL
                using(SqlHelper sh = new SqlHelper())
                {
                    //do stuff
                }
    
                //call new DAL function
    
                //call other DAL function
    
                ts.Complete();            
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
