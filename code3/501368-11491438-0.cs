     ExamoleEntities context= new ExamoleEntities ();
     bool success = false;
     using (TransactionScope transaction = new TransactionScope())
       {
         try
         {
            //your Code Here
            //
            context.SaveChanges(...);
            transaction.Complete();
            success = true;
         }
         catch (Exception ex)
         {
           // Handle errors and rollback here and retry if needed.
           // retry, otherwise stop the execution.
           Console.WriteLine("An error occured. "
                                + "The operation cannot be retried."
                                + ex.Message);                                
          }
     if (success)
            {
                
                context.AcceptAllChanges();
            }
            else
            {
                Console.WriteLine("Error");
            }
            context.Dispose();
        }
    }
