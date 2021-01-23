    void Main()
    {
        new Thread(() => doWork()).Start();
        Console.ReadLine();
    }
    public void doWork()
    {
        int h = 0;
        do
        {
            Thread.Sleep(3000);
            h.Dump();
            h++;
        }while(true);
    }
