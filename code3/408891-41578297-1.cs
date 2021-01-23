    /// <summary>
    /// Rebases file with path fromPath to folder with baseDir.
    /// </summary>
    /// <param name="_fromPath">Full file path (absolute)</param>
    /// <param name="_baseDir">Full base directory path (absolute)</param>
    /// <returns>Relative path to file in respect of baseDir</returns>
    static public String makeRelative(String _fromPath, String _baseDir)
    {
        String pathSep = "\\";
        String fromPath = Path.GetFullPath(_fromPath);
        String baseDir = Path.GetFullPath(_baseDir);            // If folder contains upper folder references, they gets lost here. "c:\test\..\test2" => "c:\test2"
        String[] p1 = Regex.Split(fromPath, "[\\\\/]").Where(x => x.Length != 0).ToArray();
        String[] p2 = Regex.Split(baseDir, "[\\\\/]").Where(x => x.Length != 0).ToArray();
        int i = 0;
        for (; i < p1.Length && i < p2.Length; i++)
            if (String.Compare(p1[i], p2[i], true) != 0)    // Case insensitive match
                break;
        if (i == 0)     // Cannot make relative path, for example if resides on different drive
            return fromPath;
                
        String r = String.Join(pathSep, Enumerable.Repeat("..", p2.Length - i).Concat(p1.Skip(i).Take(p1.Length - i)));
        return r;
    }
