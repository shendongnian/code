    Dictionary<string, List<Regex>> everything = new Dictionary<string, List<Regex>>()
    {
        { "Type1", "49 48 29 ai au2".Split(' ').Select(d => new Regex("-" + d + "-")).ToList() },
        { "Type2", "ki[0-9] 29 ra9".Split(' ').Select(d => new Regex("-" + d + "-")).ToList() },
    }
    
    string GetInputType(string input)
    {
        var codeSegments = input.ToLower().Split('-');
        if(codeSegments.Length < 2) return "NULL";
        
        string code = "-" + codeSegments[1] + "-";
        var matches = everything
            .Where(kvp => kvp.Value.Any(r => r.IsMatch(code)));
            
        return matches.Any() ? matches.First().Key : "NULL";
    }
