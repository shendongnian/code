    static bool PerformMatch(string rawPattern, string value)
    {
        var adjustedPattern = rawPattern.Replace("*", ".*");
        var regex = new Regex(adjustedPattern);
        var match = regex.Match(value);
        return match.Success && match.Length == value.Length;
    }
    static void Main()
    {
        Console.WriteLine(PerformMatch("*BA*", "Oh?"));  //false
        Console.WriteLine(PerformMatch("*BA*", "BAH!")); //true
        Console.ReadLine();
    }
