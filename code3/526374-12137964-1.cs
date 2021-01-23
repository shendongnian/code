      object spResult;
      string vendorID;
      try   
      {     
         SqlCon.Open();   
         spResult = cmd.ExecuteScalar();  
         if(spResult != null)  // check to make sure you got something back!
         {
             vendorID = spResult.ToString();
         }        
      }  
