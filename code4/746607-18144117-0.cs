    public static int i;
    public static ManualResetEvent mre = new ManualResetEvent(false);
    public static void Waiter()
    {
        mre.WaitOne();
        Console.WriteLine("Finished waiting");
    }
    public static void Main()
    {
        i = 10;
        new Thread(Waiter).Start();
        while (true)
        {
            // Press 10 keys
            Console.ReadKey();
            // Interlocked.Decrement returns the NEW value of i
            // Even in heavy multithread environments, there is the
            // guarantee that only one Interlocked.Decrement will
            // decrease the value to 0
            if (Interlocked.Decrement(ref i) == 0)
            {
                mre.Set();
                break;
            }
        }
    }
