    static void Main(string[] args)
    {
       Thread t1 = new Thread(Thread1);
       Thread t2 = new Thread(Thread2);
    
       t1.Start();
       t2.Start();
    }
    
    static void Thread1()
    {
       Console.WriteLine("Thread1 Working Dir is: {0}", ThreadEnvironment.CurrentDirectory);
       ThreadEnvironment.CurrentDirectory = @"C:\";
       Console.WriteLine("Thread1 Working Dir is: {0}", ThreadEnvironment.CurrentDirectory);
    }
    
    static void Thread2()
    {
       Console.WriteLine("Thread2 Working Dir is: {0}", ThreadEnvironment.CurrentDirectory);
       ThreadEnvironment.CurrentDirectory = @"C:\Windows";
       Console.WriteLine("Thread2 Working Dir is: {0}", ThreadEnvironment.CurrentDirectory);
    }
