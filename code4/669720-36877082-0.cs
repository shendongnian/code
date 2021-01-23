    public static string ReplaceAllButFirst(this string originalStr, string search, string replace)
    {
        string str = originalStr.Substring(0, originalStr.IndexOf(search, System.StringComparison.InvariantCultureIgnoreCase) + search.Length);
        return str + originalStr.Substring(str.Length).Replace(search, replace);  
    }
}
