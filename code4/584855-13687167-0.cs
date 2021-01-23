    public void testThread(int arg1, ConsoleColor color, object lockObj)
    {
        for (int i = 0; i < 1000; i++)
        {
            lock(lockObj)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("Thread " + color.ToString() + " : " + i);
                Console.ResetColor();
            }
            Thread.Sleep(arg1);
        }
    }
    var lockObj = new object();
    Thread t1 = new Thread(() => program.testThread(1000, ConsoleColor.Blue, lockObj));
    Thread t2 = new Thread(() => program.testThread(1000, ConsoleColor.Red, lockObj));
