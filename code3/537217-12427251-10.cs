    private static IEnumerable<int> interestingIntGenertionMethod(int maxValue)
    {
        for (int i = 0; i < maxValue; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine("actually generating value: {0}", i);
            yield return i;
        }
    }
    
    public static void Main(string[] args)
    {
        IEnumerable<int> sequence = interestingIntGenertionMethod(10)
            .SingleEnumeration();
    
        int numThreads = 3;
        for (int i = 0; i < numThreads; i++)
        {
            int taskID = i;
            Task.Factory.StartNew(() =>
            {
                foreach (int value in sequence)
                {
                    Console.WriteLine("Task: {0} Value:{1}",
                        taskID, value);
                }
            });
        }
    
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
