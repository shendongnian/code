    static void Main()
    {
        pcount = Environment.ProcessorCount;
        Console.WriteLine("Proc count = " + pcount);
        ThreadPool.SetMinThreads(4, -1);
        ThreadPool.SetMaxThreads(4, -1);
      //  System.Threading.Thread.Sleep(20000);
        Console.WriteLine("check point 0 ");
        t1 = new Task(A, 1);
        t2 = new Task(A, 2);
        t3 = new Task(A, 3);
        t4 = new Task(A, 4);
        Console.WriteLine("Starting t1 " + t1.Id.ToString());
        t1.Start();
        Console.WriteLine("Starting t2 " + t2.Id.ToString());
        t2.Start();
        Console.WriteLine("Starting t3 " + t3.Id.ToString());
        t3.Start();
        Console.WriteLine("Starting t4 " + t4.Id.ToString());
        t4.Start();
        //  Console.ReadLine();
        t1.Wait();
        t2.Wait();
        t3.Wait();
        t4.Wait();
    }
