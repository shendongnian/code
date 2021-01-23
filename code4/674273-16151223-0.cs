    public static IEnumerable<string> GetScriptSection(string file, string section)
    {
        var startMatch = string.Format("[{0}]", section);
        var endMatch = string.Format("[/{0}]", section);
        var lines = file.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        
        int startIndex = lines.FindIndex(f => f == startMatch) + 1;
        int endIndex = lines.FindLastIndex(f => f == endMatch);
        
        if(endIndex == -1)
        {
            endIndex = lines.FindIndex(startIndex,  f => f.StartsWith("[") && lines.IndexOf(f) > startIndex);
            endIndex = endIndex == -1 ? lines.Count : endIndex;
        }
        
        return lines.GetRange(startIndex, endIndex - startIndex).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
    }
