    var text = "\"one\",2,3,\"four \"\",\"five\"";
    
    var collection = text
        .Split(',')
        .Select(s =>
                    {
                        if (s.StartsWith("\"") && s.EndsWith("\""))
                        {
                            s = s.Substring(1, s.Length - 2);
                        }
                        return s;
                    })
        .ToList();
    
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }
