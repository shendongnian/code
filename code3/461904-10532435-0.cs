    public ISet<string> GetNewLinks(string content)
    {
        Regex regex = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");
        ISet<string> newLinks = new HashSet<string>();    
        foreach (var match in regexLink.Matches(content))
        {
            if (!newLinks.Contains(match.ToString()))
                newLinks.Add(match.ToString());
        }
        return newLinks;
    }
