    static void Main(string[] args)
    {
        var stringList = new List<string> 
            { "Rox", "Stephens", "Manahat", "Lexus", ":)" };
        foreach(var s in stringList)
        {
            Console.WriteLine(s);
        }
        
        Console.ReadKey();
    }
