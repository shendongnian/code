    static void Main(string[] args)
    {
        Console.WriteLine("Input please:");
        string input = Console.ReadLine();
        // Parse input with Regex
        Regex r = new Regex("\"[^\"\\\\]*(?:\\\\.[^\"\\\\]*)*\"");
        // Or with String.Split()
        string inpProcessed = input.Split('\"');
        // Or some other way...
    }
