    public static string GetSubdirectoryFromPath(string path, string parentDirectory)
    {
        string safePath = path.Replace("/", @"\");
        string safeParentDirectory = parentDirectory.Replace("/", @"\").TrimEnd('\\');
        string directory = Regex.Escape(safeParentDirectory);
        Regex match = new Regex(@".+" + directory + @"\\([^\\]+)(?:|.+)");
        return match.Match(path).Groups[1].ToString();
    }
