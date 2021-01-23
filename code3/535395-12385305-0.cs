    using System.Text.RegularExpressions;
    //... Put this in the main method of a Console Application for instance.
    Regex reg = new Regex(@"^((?<string1>([^\|]|\\\|)+)\|)((?<string2>([^\|]|\\\|)+)\|)(?<string3>([^\|]|\\\|)+)$");
    string toTest = @"user\|dureuill|deserves|an\|upvote";
    MatchCollection matches = reg.Matches(toTest);
    if (matches.Count != 1)
    {
        throw new FormatException("Bad formatted pattern.");
    }
            
    Match match = matches[0];
    string string1 = match.Groups["string1"].Value.Replace(@"\|", "|");
    string string2 = match.Groups["string2"].Value.Replace(@"\|", "|");
    string string3 = match.Groups["string3"].Value.Replace(@"\|", "|");
    Console.WriteLine(string1);
    Console.WriteLine(string2);
    Console.WriteLine(string3);
    Console.ReadKey();
