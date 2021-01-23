    public IEnumerable<int> FindPatternIndexes(string input, string search)
    {
        var sb = new StringBuilder(input);
        
        for (var i = 0; search.Length <= sb.Length; i++)
        {
            if (sb.ToString().StartsWith(search)) yield return i;
            sb.Remove(0,1);
        }
    }
