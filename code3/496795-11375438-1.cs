    public Boolean UseRowKey 
    {  
       get
       {
           if(!String.IsNullOrEmpty(RowKey))
           {
               return RowKey[0] == 'X'; 
           }
           return false;
       }
       
 
    }
