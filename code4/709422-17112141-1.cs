    var patterns = new string[] { "12ABC", "D", "A","AB","ABC","A2B3","A1BC", "A123", "123ABC12" };
    var regex = new Regex(@"^[A-Z]{1,3}$");
    foreach (var pattern in patterns)
    {
        var isMatch = regex.Match(pattern);
        if (isMatch.Success)
        Console.WriteLine("Found Matching string {0}", pattern);
    }
