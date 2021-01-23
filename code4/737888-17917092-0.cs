    try
    {
       using (TransactionScope transScope = new TransactionScope())
       {
          string myConnStringLocal = ...;
          using (var connectionLocal = new MySqlConnection(myConnStringLocal))
          {
             connectionLocal.Open();
             // do your DB update 
             
          } //no need to close connection explicitly, the using() {..} statement does that for you
    
          string myConnStringCentral = ...;
          using (var connectionCentral = new MySqlConnection(myConnStringCentral))
          {
             connectionCentral.Open();
             // do your DB update
             
          } //no need to close connection explicitly, the using() {..} statement does that for you
          
          string myConnStringCentralCopy = ...;
          using (var connectionCentralCopy = new MySqlConnection(myConnStringCentralCopy))
          {         
             connectionCentralCopy.Open();
             // do your DB update
             
          } //no need to close connection explicitly, the using() {..} statement does that for you
          
          transScope.Complete();
          
          Console.WriteLine("Transaction is completed");
          
       } //no need to dispose transactionScope explicitly, the using() {..} statement does that for you
    }
    catch (Exception)
    {
          // If any exception occurs in the try block above transScope.Complete() line will be caught here
          // and will automatically cause the transaction to rollback.
          Console.WriteLine("Transaction is rolled back");
    }
    
    // You can then start new TransactionScope if you want to further update more than one DB in a transactional manner.
    try
    {
       using (TransactionScope transScope = new TransactionScope())
       {
          //...
          
       }
    }
    catch (Exception)
    {
         //...
    }
