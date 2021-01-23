    var checkers = new string[] {"At the speed of blah blah blah", "A the speed of blah blah blah", "B the speed of blah blah blah",
    							"C the speed of blah blah blah", "D the speed of blah blah blah", "Dt the speed of blah blah blah",
    							"E the speed of blah blah blah"};
    
    var regex = @"^([A-D] )";
    
    foreach (var checker in checkers)
    {
    	var matches = Regex.Match(checker, regex);
    	Console.WriteLine (matches.Success);
    }
