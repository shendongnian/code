    void Main()
    {
        string ex = "aabbbbchhhhaaaacc";
        var groups = ex
            .ToCharArray()
            .GroupBy(c => c);
    
        foreach (var group in groups)
            Debug.WriteLine(new string(group.Key, group.Count()));
    }
