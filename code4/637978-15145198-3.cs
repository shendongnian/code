    var toSend = new BlockingCollection<int>();            
    Parallel.Invoke(() => Produce(toSend), () => Consume(toSend));
    ...
    private static void Consume(BlockingCollection<int> toSend)
    {
        foreach (var value in toSend.GetConsumingEnumerable())
        {
            Console.WriteLine("Sending {0}", value);
        }
    }
    private static void Produce(BlockingCollection<int> toSend)
    {
        Action<int> generateToSend = toSend.Add;
        var producers = Enumerable.Range(0, 1000)
                                  .Select(n => new Task(value => generateToSend((int) value), n))
                                  .ToArray();
        foreach(var p in producers)
        {
            p.Start();
        }
        Task.WaitAll(producers);
        toSend.CompleteAdding();
    }
