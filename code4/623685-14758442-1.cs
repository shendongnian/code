    public string PathDiff(string path1, string path2)
    {
        var replace1 = path1.Replace(path2, string.Empty);
        var replace2 = path2.Replace(path1, string.Empty);
        return Path.IsPathRooted(replace1) ? replace2 : replace1;
    }
