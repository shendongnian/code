    static void Main(string[] args)
    {
        string v = "A: 1,5 ,B:2,44,C: 3,54,D: 5,11";
        IEnumerable<string> result = Foo(v).ToArray();
        // A: 1,5
        // B:2,44
        // C: 3,54
        // D: 5,11
    }
    
    public static IEnumerable<string> Foo(string s)
    {
        var sb = new StringBuilder();
        bool shouldFlush = false;
        bool firstIteration = true;
        foreach (char c in s)
        {
            if (!firstIteration)
            {
                shouldFlush = char.IsLetter(c);
            }
            if (shouldFlush)
            {
                string result = sb.ToString().Trim(' ', ',');
                sb.Clear();
                yield return result;
            }
    
            sb.Append(c);
            firstIteration = false;
        }
    
        yield return sb.ToString().Trim(' ', ',');
    }
