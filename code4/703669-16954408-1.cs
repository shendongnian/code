    static void Main(string[] args)
    {
        var info = "628      5911.3097      1660.0134      3771.8285              0";
        Console.WriteLine(info);
        Console.WriteLine();
    
        string[] split = info.Split((char[])null,StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in split)
            Console.WriteLine("\"" + s + "\" is empty: " + (s.Length == 0));
    
        //What happens if we concat the strings?
        Console.WriteLine();
        Console.WriteLine(string.Concat(split));
    
        Console.ReadLine();
        
        /*
        628      5911.3097      1660.0134      3771.8285              0
        
        "628" is empty: False
        "5911.3097" is empty: False
        "1660.0134" is empty: False
        "3771.8285" is empty: False
        "0" is empty: False
        
        6285911.30971660.01343771.82850
        */
    }
