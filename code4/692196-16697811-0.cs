    string l_pattern = @"(?i)(?=(?<Cond1>.*?Begin)+)?(?=(?<Cond2>.*?Middle)+)?(?=(?<Cond3>.*?End)+)?";
    string l_input = "Hello this is Begin.This is another begin.Hello this is Middle.";
    var l_match = Regex.Match( l_input, l_pattern );
    Console.WriteLine( "Cond1 matched {0} times.", l_match.Groups["Cond1"].Captures.Count );
    Console.WriteLine( "Cond2 matched {0} times.", l_match.Groups["Cond2"].Captures.Count );
    Console.WriteLine( "Cond3 matched {0} times.", l_match.Groups["Cond3"].Captures.Count );
    
    Console.ReadKey( true );
