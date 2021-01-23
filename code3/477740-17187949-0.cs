    static void Main(string[] args)
    {
       var sem = new Semaphore(0, 1);
            
        Action<object> work1 = o =>
        {
            sem.WaitOne();
            Console.WriteLine("enter " + o);
            Thread.Sleep(2000);
            Console.WriteLine("exit " + o);
        };
        Action<object> work2 = o =>
        {
            Console.WriteLine("enter " + o);
            Thread.Sleep(2000);
            Console.WriteLine("exit " + o);
            sem.Release();
        };
        work1.BeginInvoke("first", ar => { }, null);
        work2.BeginInvoke("second", ar => { }, null);       
        Console.ReadKey();
    }
