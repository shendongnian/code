    class AddTakeDemo
    {
        // Demonstrates: 
        //      BlockingCollection<T>.Add() 
        //      BlockingCollection<T>.Take() 
        //      BlockingCollection<T>.CompleteAdding() 
        public static void BC_AddTakeCompleteAdding()
        {
            // here you need to synch as it would have missed any 
            // new files while the application was down
            using (BlockingCollection<int> bc = new BlockingCollection<int>())
            {
    
                // Spin up a Task to populate the BlockingCollection  
                using (Task t1 = Task.Factory.StartNew(() =>
                {
                    //  FielSystem watcher                    
                    bc.Add(fille);
                }))
                {
    
                    // Spin up a Task to consume the BlockingCollection 
                    using (Task t2 = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            // Consume consume the BlockingCollection 
                            while (true) Console.WriteLine(bc.Take());
                            // process the file
                        }
                        catch (InvalidOperationException)
                        {
                            // An InvalidOperationException means that Take() was called on a completed collection
                            Console.WriteLine("That's All!");
                        }
                    }))
    
                        Task.WaitAll(t1, t2);
                }
            }
        }
    }
