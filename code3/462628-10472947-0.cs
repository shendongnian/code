    private IDictionary<string, string[]> prefixedStrings;
    public void Construct(IEnumerable<string> strings)
    {
        this.prefixedStrings =
            (
                from s in strings
                from i in Enumerable.Range(1, s.Length)
                let p = s.Substring(0, i)
                group s by p
            ).ToDictionary(
                g => g.Key,
                g => g.ToArray());
    }
    public string[] Search(string prefix)
    {
        string[] result;
        if (this.prefixedStrings.TryGetValue(prefix, out result))
            return result;
        return new string[0];
    }
