    public List<string> GetUsersFrom(string fileName)
    {
       return File.ReadAllLines(fileName)
                  .Select(ParseUser)
                  .Where(u => u != null && u != "null")
                  .ToList();
    }
    
    private string ParseUser(string s) // Any implementation here
    {
        var match = Regex.Match(s, @"appGUID:\s*(?<user>\S+)");
        if (!match.Success)
            return null;
    
        return match.Groups["user"].Value;
    }
