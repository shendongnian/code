    var input = new[] { "xx - c", "xx - b", "yy - a", "ml - d",  };
    var delimeter = "-";
    var isAscending = true;
    
    var stringsWithDelimeter = input.Where(p => p.Contains(delimeter));
    
    Func<string,string> selector = p => p.Substring(p.IndexOf(delimeter));
    
    var sorted = (isAscending
        ? stringsWithDelimeter.OrderBy(selector)
        : stringsWithDelimeter.OrderByDescending(selector))
                    
        .ToArray(); 
