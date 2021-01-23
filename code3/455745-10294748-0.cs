    String text = "aaaabaa";
    Regex reg = new Regex(@"(\p{L})(?=\1)");
    
    MatchCollection result = reg.Matches(text);
    
    foreach (Match item in result) {
        Console.WriteLine(item.Index);
    }
