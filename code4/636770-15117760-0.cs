    try
    {
      int retrysLeft = 10;
      while (retrysLeft >= 0)
      {
         try 
         {
            // attempt to download
            retrysLeft = -1;
         }
         catch (WebException ex)
         {
            if (ex.InnerException.Message.Contains("used by another process"))
            {
               retrysLeft--;
               Thread.Sleep(1000);
            }
            else throw;
         }
       }
     }
     catch (Exception ex)
     {
        // Regular error handling
     }
