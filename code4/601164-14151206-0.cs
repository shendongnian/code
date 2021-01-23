    static string SearchDirectory(string path, string pattern)
    {
        var regex = new Regex(pattern);
        foreach (var d in Directory.GetDirectories(path))
        {
            var dirName = d.Substring(d.LastIndexOf('\\') + 1);
            if (regex.IsMatch(dirName)) return d;
            SearchDirectory(d, pattern);
        }
        return null;
        //Or throw an Exception
    }
