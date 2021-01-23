    public static string GetSubdirectoryFromPath(string path, string parentDirectory, bool ignoreCase = true)
    {
        // 1. Standarize the path separators.
        string safePath = path.Replace("/", @"\");
        string safeParentDirectory = parentDirectory.Replace("/", @"\").TrimEnd('\\');
        // 2. Prepare parentDirectory to use in Regex.
        string directory = Regex.Escape(safeParentDirectory);
        // 3. Find the immediate subdirectory to parentDirectory.
        Regex match = new Regex(@"(?:|.+)" + directory + @"\\([^\\]+)(?:|.+)", ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
        // 4. Return the match. If not found, it returns null.
        string subDirectory = match.Match(path).Groups[1].ToString();
        return subDirectory == "" ? null : subDirectory;
    }
