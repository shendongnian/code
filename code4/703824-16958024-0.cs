    private static readonly Regex TestRegex = new Regex(@"^([A-Za-z0-9]+) Ticket Update- ID:\1 with Priority:\1 A New ticket/action item is assigned to you in GSD\.$");
    public bool IsValid(string testString)
    { 
       return (TestRegex.IsMatch(testString));
    }
