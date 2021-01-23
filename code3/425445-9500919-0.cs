    static BlockingCollection<Action<StringBuilder>> queue = new BlockingCollection<Action<StringBuilder>>();
    
    //Your thread unsafe resource...
    static StringBuilder resource = new StringBuilder();
    
    static void Main(string[] args)
    {
        Task.Factory.StartNew(() =>
        {
            while (true)
            {
                var action = queue.Take();
                action(resource);
            }
        });
    
        //Now to do some work you simply add something to the queue...
        queue.Add((sb) => sb.Append("Hello"));
        queue.Add((sb) => sb.Append(" World"));
    
        queue.Add((sb) => Console.WriteLine("Content: {0}", sb.ToString()));
    
        Console.ReadLine();
    }
