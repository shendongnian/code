    public static string Trim(this string s, string trimmer)
    {
        string reversed = string.Concat(s.Reverse());
        if (trimmer.Reverse().Where((c, i) => reversed[i] != c).Any())
            return s;
        else
            return s.Substring(0, s.Length - trimmer.Length);
    }
