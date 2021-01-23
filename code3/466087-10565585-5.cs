    private Collection<T> ExecuteReader(params object[] p)
    {
        ...
        var matches = Regex.Matches(sql, @"@\w+");
        if (matches.Count != p.Length) {
            throw new ArgumentException("The # of parameters does not match ...");
        }
        for (int i = 0; i < p.Length; i++) {
            command.Parameters.AddWithValue(matches[i].Value, p[i]);
        }
        ...
    }
