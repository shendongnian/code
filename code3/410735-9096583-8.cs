    static void Main(string[] args)
    {
        Registry r = new Registry();
        List<Thread> threads = new List<Thread>();
        var lastNo = 0;
        r.Register(0, "0");
        for (int i = 1; i < 500; i++)
        {
            var k = i;
            threads.Add(new Thread(() =>
            {
                Console.WriteLine("Write: " + k);
                r.Register(k, k.ToString());
            }));
            threads.Add(new Thread(() =>
            {
                Console.WriteLine("Read last: " + r.Ids.Last());
                lastNo = r.Ids.Last();
            }));
        }
            
        threads.ForEach(t => t.Start());
        // poll until finished
        while (lastNo != 499) Thread.Sleep(100);
        Console.WriteLine("done");
        Console.Read();
    }
