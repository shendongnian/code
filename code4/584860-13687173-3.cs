    private static readonly object myLock = new object();
    public void testThread(int arg1, ConsoleColor color)
    {
        for (int i = 0; i < 1000; i++)
        {
            lock (myLock) {
                Console.ForegroundColor = color;
                Console.WriteLine("Thread " + color.ToString() + " : " + i);
                Console.ResetColor();
            }
            Thread.Sleep(arg1);
        }
    }
