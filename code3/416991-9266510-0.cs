    static void Main(string[] args)
    {
        var exe = Environment.GetCommandLineArgs().FirstOrDefault();
        Console.WriteLine("EXE: {0}", exe);
        foreach (var arg in args)
        {
            Console.WriteLine("arg: {0}", arg);
        }
    }
