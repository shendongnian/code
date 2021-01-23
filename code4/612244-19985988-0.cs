          public async Task MyMethod() 
          {
            Task<int> longRunningTask = LongRunningOperation(); 
             //indeed you can do independent to the int result work here 
             
              //and now we call await on the task 
              int result = await longRunningTask; 
              //use the result 
              Console.Writeline(result);
          }
          public async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
           {
              await Task.Delay(1000); //1 seconds delay
              return 1;
           }
