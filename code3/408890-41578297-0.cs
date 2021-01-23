    /// <summary>
    /// Rebases file with path fromPath to folder with baseDir.
    /// </summary>
    /// <param name="fromPath">Full file path (absolute)</param>
    /// <param name="baseDir">Full base directory path (absolute)</param>
    /// <returns>Relative path to file in respect of baseDir</returns>
    static public String makeRelative(String fromPath, String baseDir)
    {
        String pathSep = "\\";
        String[] p1 = Regex.Split(fromPath, "[\\\\/]").Where(x => x.Length != 0).ToArray();
        String[] p2 = Regex.Split(baseDir, "[\\\\/]").Where(x => x.Length != 0).ToArray();
        int i = 0;
        for (; i < p1.Length && i < p2.Length; i++)
            if (String.Compare(p1[i], p2[i], true) != 0)    // Case insensitive match
                break;
        String r = String.Join(pathSep, Enumerable.Repeat("..", p1.Length - i - 1).Concat(p2.Skip(i).Take(p2.Length - i)) );
        
        if (r.Length == 0)
            r = p1.Last();
        else
            r = String.Join(pathSep, r, p1.Last());
        return r;
    }
