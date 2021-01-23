    public static string GetSubdirectoryFromPath(string path, string parentDirectory)
    {
        // 1. Standarize the path separators.
        string safePath = path.Replace("/", @"\");
        string safeParentDirectory = parentDirectory.Replace("/", @"\").TrimEnd('\\');
        // 2. Prepare parentDirectory to use in Regex.
        string directory = Regex.Escape(safeParentDirectory);
        // 3. Find the immediate subdirectory to parentDirectory.
        Regex match = new Regex(@"(?:|.+)" + directory + @"\\([^\\]+)(?:|.+)");
        // 4. Return the match. If not found it returns empty string "".
        return match.Match(path).Groups[1].ToString();
    }
