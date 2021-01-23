    const string pattern = @"\b\d{5}-\d{2}\b";
    
    Regex.IsMatch("12345", pattern).Dump(); // no match
    Regex.IsMatch("12345-12", pattern).Dump(); // match
    Regex.IsMatch("12345-1234", pattern).Dump(); // no match
    Regex.IsMatch("word 12345 word", pattern).Dump(); // no match
    Regex.IsMatch("word 12345-12 word", pattern).Dump(); // match
    Regex.IsMatch("word 12345-1234 word", pattern).Dump(); // no match
    Regex.IsMatch("word@12345-12@word", pattern).Dump(); // match
 
