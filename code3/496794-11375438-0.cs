    public Boolean UseRowKey 
    {  
       get
       {
           if(!String.IsNullOrEmpty(RowKey))
           {
               return UserRowKey[0] == 'X'; 
           }
           return false;
       }
       
 
    }
