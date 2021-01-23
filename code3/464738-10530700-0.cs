    string input = "test testabc test123 abc abctest";
    string pattern = @"(abc\b)";
    string replacement = "";
    Regex rgx = new Regex(pattern);
    string result = rgx.Replace(input, replacement);
    
    Console.WriteLine("Original String: {0}", input);
    Console.WriteLine("Replacement String: {0}", result);
