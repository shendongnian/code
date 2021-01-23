    static void Main(string[] args)
    {
        Console.Write(string.Empty);
        Timer timer = new Timer(100);
        timer.Elapsed += new ElapsedEventHandler(WriteOnConsole);
        timer.Start();
        Console.ReadKey();
        Console.ReadKey();
    }
    static void WriteOnConsole(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("A B C D");
    }
