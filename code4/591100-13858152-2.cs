    public static string AddIncrementFileNameSuffix(string path, IList<string> paths, string separator)
    {
        string dir = Path.GetDirectoryName(path);
        string ext = Path.GetExtension(path);
        string fileName = Path.GetFileName(path);
        string[] tokens = fileName.Split(new[] { separator }, StringSplitOptions.None);
        int num = 0;
        int.TryParse(tokens.Last(), out num);
 
        var dups = paths.Where(n => n.Equals(path, StringComparison.OrdinalIgnoreCase));
        while (dups.Any())
        {
            path = Path.Combine(dir, tokens.First() + separator + ++num + ext);
        }
        paths.Add(path);
        return path;
    }
