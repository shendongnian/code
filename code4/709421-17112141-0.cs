    var patterns = new string[] {"12ABC", "D", "ABC", "A123", "123ABC12"};
    var regex = new Regex(@"^[A-Z]$");
    foreach (var pattern in patterns)
    {
        var isMatch = regex.Match(pattern);
        if(isMatch.Success)
        Console.WriteLine("Found Matching string {0}",pattern);
    }
