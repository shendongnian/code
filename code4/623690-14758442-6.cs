    public string PathDiff(string path1, string path2)
    {
        return path1.Length > path2.Length ? 
            path1.Replace(path2, string.Empty) : 
            path2.Replace(path1, string.Empty);
    }
