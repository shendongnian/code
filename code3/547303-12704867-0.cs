    static void Main(string[] args)
    {
        Console.WriteLine("\nUsing Parallel.For \n");
        Parallel.For(0, 10, i =>
        {
            Console.WriteLine("i = {0}, thread = {1}", i, Function1());
            Thread.Sleep(10);
        });
        Console.ReadLine();
    }
    static int Function1()
    {
        return Thread.CurrentThread.ManagedThreadId; 
    }
