    private static readonly object lockObject=new object();
    public void testThread(int arg1, ConsoleColor color)
    {
        for (int i = 0; i < 1000; i++)
        {
            lock (lockObject) {
              Console.ForegroundColor = color;
              Console.WriteLine("Thread " + color.ToString() + " : " + i);
              Console.ResetColor();
            }
            Thread.Sleep(arg1);
        }
    }
    Thread t1 = new Thread(() => program.testThread(1000, ConsoleColor.Blue));
    Thread t2 = new Thread(() => program.testThread(1000, ConsoleColor.Red));
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
