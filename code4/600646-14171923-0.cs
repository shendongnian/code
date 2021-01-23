    private static void ManualAsyncOperation()
            {
               
                Task<string> task = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Accessing database .....");
                        //Mimic the DB operation 
                        Thread.Sleep(1000);
                        
                        return "Hello wolrd";
                    },TaskCreationOptions.LongRunning);
    
                var awaiter =task.GetAwaiter();
                awaiter.OnCompleted(() =>
                    {
                        try
                        {
                            var result = awaiter.GetResult();
    
                            Console.WriteLine("Result: {0}", result);
                        }
                        catch (Exception exception)
                        {
    
                            Console.WriteLine("Exception: {0}",exception);
                        }
                    });
                Console.WriteLine("Continuing on the main thread and waiting for the result ....");
                Console.WriteLine();
    
                Console.ReadLine();
    
            }
