    volatile static int lastNo = 0;
    static void Main(string[] args)
    {
        Registry r = new Registry();
        r.Register(0, "0");
        List<Thread> threads = new List<Thread>();
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
        while (lastNo != 499)
            Thread.Sleep(100);
        Console.WriteLine("done");
        Console.Read();
    }
