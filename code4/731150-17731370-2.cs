    static void Main() //Main(string[] args)
    {
        string[] messages = "this is a test.  but it's going to be an issue!".Split(' ');
    
        Parallel.ForEach(messages, Log);
    
        Console.ReadLine();
    }
    [ThreadStatic]
    static bool _disable = false;
    public static void Log(string message)
    {
        if (_disable)
        {
            return;
        }
        try {
            _disable = true;
            Console.WriteLine(GetPrefix() + message);
        } finally {
            _disable = false;
        }
    }
    
    public static string GetPrefix()
    {
        Log("Getting prefix!");
        return "Prefix: ";
    }
