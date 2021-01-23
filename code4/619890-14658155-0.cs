    string input = "?where[column]=value&where[column2]=value2&orderby[column]=asc&orderby[column2]=desc";
    string pattern = @"(?<Type>[^[]+)\[(?<Key>[^]]+)\]=(?<Value>.+)";
    var re = new Regex(pattern);
    var dict = input.Split(new[] { "?", "&" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => re.Match(s))
                    .GroupBy(m => m.Groups["Type"].Value)
                    .ToDictionary(g => g.Key,
                        g => g.ToDictionary(x => x.Groups["Key"].Value,
                                            x => x.Groups["Value"].Value));
    
    foreach (var t in dict.Keys)
    {
        Console.WriteLine("Type: " + t);
        foreach (var k in dict[t].Keys)
        {
            Console.WriteLine("{0}: {1}", k, dict[t][k]);
        }
    }
