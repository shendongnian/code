    // regex to match the inner most patterns of n(X) and capture the values of n and X.
    private static readonly Regex matcher = new Regex(@"(\d+)\(([^(]*?)\)", RegexOptions.None);
            
    // create new string by repeating X n times, separated with ','
    private static string Join(Match m)
    {
        var n = Convert.ToInt32(m.Groups[1].Value); // get value of n
        var x = m.Groups[2].Value; // get value of X
        return String.Join(",", Enumerable.Repeat(x, n));
    }
    
    // expand the string by recursively replacing the innermost values of n(X).
    private static string Expand(string text)
    {
        var s = matcher.Replace(text, Join);
        return (matcher.IsMatch(s)) ? Expand(s) : s;
    }
    
    // parse a string for occurenses of n(X) pattern and expand then.
    // return the string as a tokenized array.
    public static string[] Parse(string text)
    {
        // Check that the number of parantheses is even.
        if (text.Sum(c => (c == '(' || c == ')') ? 1 : 0) % 2 == 1)
            throw new ArgumentException("The string contains an odd number of parantheses.");
    
        return Expand(text).Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
