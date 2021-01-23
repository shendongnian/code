    using(TransactionScope scope1 = new TransactionScope())
    {
         //i insert some records in tabe A
         try
         {              
              using(TransactionScope scope2 = new
                 TransactionScope(TransactionScopeOption.Suppress))
              {                  
                   // I insert some records in table B
              }
              //I insert some records in table C
       }
         catch
         {}
       //I Update some records in table D
       //I Delete some records of table E
       // Here we have an exception being thrown                       
     
    }
