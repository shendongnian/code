    bool isRunning;
    
    public void Main
    {
        Thread t = new Thread(Method);
        t.Start();
        isRunning = true;
    }
    
    public void Method(int i)
    {
        while(isRunning)
        {
            i = 0;
            i++;
            Thread.Sleep(0);
            Console.WriteLine(i);
        }
    }
