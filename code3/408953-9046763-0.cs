            BlockingCollection<string> _streamingData = new BlockingCollection<string>();
            Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        _streamingData.Add(i.ToString());
                        Thread.Sleep(100);
                    }
                });
            new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Thread count: " + Process.GetCurrentProcess().Threads.Count);
                    }
                }).Start();
            Parallel.ForEach(_streamingData.GetConsumingEnumerable(), item =>
                {
                });
