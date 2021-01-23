    public static string[] GetHierarchy(this string path)
    {
        var res = path.Split('.');
        string last = null;
        for (int i = 0; i < res.Length; ++i)
        {
            last = string.Format("{0}{1}{2}", last, last != null ? "." : null, res[i]);
            res[i] = last;
        }
        return res;
    }
