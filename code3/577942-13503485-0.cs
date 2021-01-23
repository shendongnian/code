    public static void Main()
    {
        Regex regex = new Regex(".+ABC(...)");
        Match match = regex.Match("baln390nABCqlcln");
        foreach (Group group in match.Groups)
        {
            Console.WriteLine(group.Value);
        }
    }
