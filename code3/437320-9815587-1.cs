    using (TransactionScope scope = new TransactionScope())
    {  
       using (SqlConnection connection1 = new SqlConnection(connectString1)) 
       {
       }
     
       using (SqlConnection connection2 = new SqlConnection(connectString2))    
       {    
       }
     
       using (SqlConnection connection3 = new SqlConnection(connectString3))    
       {    
       }
    
       scope.Complete(); // call this otherwise the transaction will be rolled back  
    }
