    static void Main(string[] args)
    {
        int n = 0;
        object lck = new object();
        var up = new Thread(() => 
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (lck)
                        n++;
                }
            });
        up.Start();
        for (int i = 0; i < 1000000; i++)
        {
            lock (lck)
                n--;
        }
        up.Join();
        Console.WriteLine(n);
        Console.ReadLine();
    }
