    public string GetFilepath(int n, string needle, string haystack) {
        int lastindex = haystack.Length;
        for (int i = nth; i >= 0; i--)
            lastindex = haystack.LastIndexOf(needle, lastindex-1);
        return haystack.Substring(lastindex);
    }
