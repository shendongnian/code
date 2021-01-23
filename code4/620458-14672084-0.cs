    string str = "abc , 123; xyz, 100; go, 9; move, 50;";
    
    stringses = str.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(s => s.Split(new[] {','}))
                   .ToArray();
