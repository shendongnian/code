    static void Main(string[] args)
    {
        int n = 0;
    
        var up = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });
    
        up.Start();
    
        for (int i = 0; i < 1000000; i++)
        {
            Interlocked.Decrement(ref n);
        }
    
        up.Join();
    
        Console.WriteLine(n);
    
        Console.ReadLine();
    }
