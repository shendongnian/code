    Task task = RunLimitedNumberAtATime(10,
        Enumerable.Range(1, 100),
        x => Task.Factory.StartNew(() => {
            Console.WriteLine($"Starting task {x}");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine($"Finishing task {x}");
        }, TaskCreationOptions.LongRunning));
