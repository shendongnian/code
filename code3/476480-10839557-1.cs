    public static void Main(string[] args)
    {
        ThreadAwareStreamWriter writer = new ThreadAwareStreamWriter();
        Console.SetOut(writer);
        Thread t = new Thread(o =>
        {
            ThreadAwareStreamWriter tWriter = (ThreadAwareStreamWriter)o;
            tWriter.RegisterThreadWriter(new StreamWriter(File.Open("test.txt", FileMode.Create, FileAccess.ReadWrite)));
            Console.WriteLine("Hello from another thread");
            tWriter.DeregisterThread();
        });
        t.Start(writer);
        Console.WriteLine("Hello");
        Console.ReadLine();
    }
