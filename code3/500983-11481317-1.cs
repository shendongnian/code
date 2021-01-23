    class Program
    {
    /// Generate test strings
    static IEnumerable<string> Generator()
    {
        yield return "3.72 million people (country rank: 6th) (2004 estimate)";
        yield return "10000 people (2007 estimate)";
    }
    public static void Main()
    {
        string expression = @"
    (?<population>\d(.\d+)?)  #capturing group named 'population'
                               #that is a number, optionally followed by a
                               #decimal point and at least one number
    \s*                        #followed by one or more spaces
    (?<magnitude>thousand|(m|b)illion)? #optional capturing group named 'magnitude'
                                        # that matches 'thousand', 'million', or 'billion'
    \s*                        #one or more whitespace characters
    people                     #the literal 'people'
    .*                         #match any number of characters
    \(                         #Find literal opening parentheses...
       (?<year>\d{4})          #...followed by a four-digit year...
    \s                         #...followed by a space...
    estimate\)                 #...followed by the phrase 'estimate'
    \s*$                       #followed by optional whitespace
                               #and the end of the string";
        RegexOptions options = 
            RegexOptions.IgnorePatternWhitespace // allow whitespace/comments
            | RegexOptions.IgnoreCase
            | RegexOptions.ExplicitCapture; // Only capture named groups
        Regex r = new Regex(expression, options);
        foreach (var test in Generator())
        {
            Match match = r.Match(test);
            if (!match.Success)
                Console.WriteLine("Could not match {0}", test);
            else
            {
                double population = double.Parse(match.Groups["population"].Value);
                if (match.Groups["magnitude"].Success) // magnitude is optional
                                                       // but if present, need to
                                                       // multiply population
                {
                    switch (match.Groups["magnitude"].Value.ToLower())
                    {
                        case "thousand": population *= 1000; break;
                        case "million": population *= 1E6; break;
                        case "billion": population *= 1E9; break;
                        default: throw new FormatException("Unexpected value in magnitude group");
                    }
                }
                int year = int.Parse(match.Groups["year"].Value);
                Console.WriteLine("In {0}, population was {1} people.", year, population);
            }
        }
    }
