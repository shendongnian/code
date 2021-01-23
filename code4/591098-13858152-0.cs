    public static string AddIncrementFileNameSuffix(string path, IList<string> paths, string separator)
    {
        int num = 0;
        string[] tokens = path.Split(new[] { separator }, StringSplitOptions.None);
        string strNum = tokens.Last();
        int.TryParse(strNum, out num);
        string fileName = path;
        string dir = Path.GetDirectoryName(path);
        string fileNameWoExt = Path.GetFileNameWithoutExtension(path);
        string ext = Path.GetExtension(path);
        var dups = paths.Where(n => n.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        while (dups.Any())
        {
            fileName = Path.Combine(dir, tokens.First() + separator + ++num + ext);
        }
        paths.Add(fileName);
        return fileName;
    }
