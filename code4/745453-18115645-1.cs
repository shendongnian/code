     for (int i = 0; i < retries; i++)
     {
         try
         {
             //do stuff that could throw
         }
         catch (Exception e)
         {
             Thread.Sleep(500);
             if (i == retries - 1)
             {
                 throw new Exception(e.Message);
             }
         }
      }
