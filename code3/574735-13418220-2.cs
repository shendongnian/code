    static void Main()
    {
        var input = new[] { "xx - c", "xx - b", "yy - a", "ml - d", };
        var delimeter = "-";
        var isAscending = true;
    
        var res = Sort(input, delimeter, isAscending);
    }
    static string[] Sort(string[] input, string delimeter, bool isAscending)
    {
        var withDelimeter = input.Where(p => p.Contains(delimeter));
        var withoutDelimeter = input.Except(withDelimeter);
    
        Func<string, string> selector = p => p.Substring(p.IndexOf(delimeter));
    
        return
            (
                isAscending
    
                    ? withDelimeter.OrderBy(selector)
                        .Concat(withoutDelimeter.OrderBy(p => p))
    
                    : withoutDelimeter.OrderByDescending(p => p)
                        .Concat(withDelimeter.OrderByDescending(selector))
            )
            .ToArray();
    }
