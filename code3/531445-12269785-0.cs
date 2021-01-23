    IEnumerable<string> Replaces(string source)
    {
        var rx = new Regex(@"\w+m", RegexOptions.IgnoreCase); // match words ending with 'm'
        var result = new List<string>(); 
        rx.Replace(source, m => { result.Add(m.ToString().ToUpper()); return m.ToString(); });
        return result;
    }
