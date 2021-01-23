    var hashSet = new HashSet<string>();
    foreach (string s in str.Split(','))
    {
        if (!string.IsNullOrWhiteSpace(s))
        {
            hashSet.Add(s.Trim());
        }
    }
