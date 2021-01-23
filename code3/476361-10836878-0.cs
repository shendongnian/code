    string pattern = @"\d{4}";
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(pattern);
    Console.WriteLine(r.Match("30 Jan 1965"));
    Console.WriteLine(r.Matches("30 Jan 1965 2001 2010 test ").Count);
    // will output 
    // 1965
    // 3
