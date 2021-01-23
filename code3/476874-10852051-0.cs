    static void Main()
    {
        if (Environment.UserInteractive)
        {
            new MyService1().Run();
            Thread.Sleep(Timeout.Infinite);
        }
        else
        {
            ServiceBase.Run(new ServiceBase[] { new MyService1() });
        }
    }
