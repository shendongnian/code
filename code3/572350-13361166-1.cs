    private static object locker = new object();
    
    static void DoStuff()
    {
        for (int i = 0; i < 500000; i++)
        {
            lock (locker)
            {
                a++;
            }
        }
    }
