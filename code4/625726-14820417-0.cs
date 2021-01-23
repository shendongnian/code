    private int GetAge (int ID)
    {
       try 
       {
            GetAgeFromFile(ID)
            
              
       }
       catch {System.IO.Exception e }
       {
            throw new CommunctionError(
            string.Format("Cannot access age file ID:{0}.",ID) ,
            e);
       }
  
    }
