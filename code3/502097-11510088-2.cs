    static void Main(string[] args)
    {
        Console.WriteLine("Input please:");
        string input = Console.ReadLine();
        // Parse input with Regex (This splits based on spaces, but ignores quotes)
        Regex regex = new Regex(@"\w+|""[\w\s]*""");
    }
