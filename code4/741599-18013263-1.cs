    Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 100);
    t.ContinueWith(tt => Console.WriteLine("Finished, SUM={0}", tt.Result),
                   TaskContinuationOptions.OnlyOnRanToCompletion);
    t.ContinueWith(tt => Console.WriteLine("Exception thrown"), 
                   TaskContinuationOptions.OnlyOnFaulted);
    t.Start();
    Console.ReadKey(); // keep app alive
