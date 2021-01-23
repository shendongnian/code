      class Program
      {
        //Not parallel, but suitable for monitoring queue purposes, 
        //can then focus on parallelizing each individual task
        static void Main(string[] args)
        {
            BlockingCollection<int> itemsQueue = new BlockingCollection<int>();
            Random random = new Random();
            var results = itemsQueue.GetConsumingEnumerable()
            .Select(i =>
            {
                Console.WriteLine("Working on " + i);
                //Focus your parallelization efforts on the work of 
                //the individual task
                //E.g, simulated:
                double work = Enumerable.Range(0, 90000000 - (10 * (i % 3)))
                .AsParallel()
                .Select(w => w + 1)
                .Average();
                Console.WriteLine("Finished " + i);
                return i;
            });
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();
            Task.Factory.StartNew(() =>
            {
                foreach (int i in results)
                {
                    Console.WriteLine("Result Available: " + i);
                }
                completion.SetResult(true);
            });
            int iterations;
            iterations = random.Next(5, 50);
            Console.WriteLine("------- iterations: " + iterations + "-------");
            for (int i = 1; i <= iterations; ++i)
            {
                itemsQueue.Add(i);
            }
            while (true)
            {
                char c = Console.ReadKey().KeyChar;
                if (c == 's')
                {
                    break;
                }
                else
                {
                    ++iterations;
                    Console.WriteLine("adding: " + iterations);
                    itemsQueue.Add(iterations);
                }
            }
            itemsQueue.CompleteAdding();
            completion.Task.Wait();
            Console.WriteLine("Done!");
            Console.ReadKey();
            itemsQueue.Dispose();
        }
    }
