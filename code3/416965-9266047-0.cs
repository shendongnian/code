    static void Main(string[] args)
    {
        var rnd = new Random();
        var n = rnd.Next(13);
    
        while (!Guess(n)) ;
    
        Console.ReadKey();
    }
    
    static bool Guess(int n)
    {
        int input;
                
        if (!int.TryParse(Console.ReadLine(), out input))
            return false;
    
        var msg = input == n ? "Win" : input < n ? "Low" : "High";
        Console.WriteLine(msg);
        return input == n;
    }
