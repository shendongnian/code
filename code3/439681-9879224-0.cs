    public void GetNames(string pattern)
    {
        var q = from n in names
            where n.Name.StartsWith(pattern)
            select n;
            
        if (q.Count() >= 3)
            return q.ToList();
        else
            return new List<NameClass>();
    }
