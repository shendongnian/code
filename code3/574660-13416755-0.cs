    static void SimpleNestedTask()
    {
        var parent = Task.Factory.StartNew(() =>
        {
            // myFunction1 code here;
            Console.WriteLine("Outer task executing.");
    
            var child = Task.Factory.StartNew((t) =>
            {
                // myFunction2 code here
                // Calls a web service and updates local files
                Console.WriteLine("Nested task completing.");
            }, TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
       });
    
        parent.Wait();
        Console.WriteLine("Outer has completed.");
    }
