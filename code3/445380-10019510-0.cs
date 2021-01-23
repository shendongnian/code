    Thread t1 = new Thread(
        new ThreadStart(()=>
        {
            for(int i = 0; i < 3; i++)
            {
                System.Console.WriteLine("ThreadA");    
                Thread.Sleep(3000)
            }
        }));
    Thread t2 = new Thread(
        new ThreadStart(()=>
        {
            for(int i = 0; i < 3; i++)
            {
                System.Console.WriteLine("ThreadB");    
                Thread.Sleep(1000)
            }
        }));
    t1.Start();
    t2.Start();
