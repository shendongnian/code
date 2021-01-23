    static void Main()
    {
        var input = new[] { "xx - c", "xx - b", "yy - a", "ml - d", };
        var delimeter = "-";
        var isAscending = true;
    
        var res = Sort(input, delimeter, isAscending);
    }
    static string[] Sort(string[] input, string delimeter, bool isAscending)
    {
        var stringsWithDelimeter = input.Where(p => p.Contains(delimeter));
    
        Func<string, string> selector = p => p.Substring(p.IndexOf(delimeter));
    
        return
            (
                isAscending
                    ? stringsWithDelimeter.OrderBy(selector)
                    : stringsWithDelimeter.OrderByDescending(selector)
            )
            .ToArray();
    }
