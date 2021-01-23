    string pattern = "[a-z\s,']+";
    string input = @"\DR1234 this is a word, 123456, frank's place DA123 SW1 :50:/";
    Match match = Regex.Match(input, pattern);
    while (match.Success){
       Console.WriteLine(match.Value);
       match = match.NextMatch();
    }
