     protected void CalculateAndNotify()
     {
         if (Monitor.TryEnter(someObject))
         {
             try
             {
                 // your code
             }
             finally
             {
                 Monitor.Exit(someObject);
             }
         }
     }
