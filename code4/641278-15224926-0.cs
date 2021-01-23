     Dictionary<int, string> mySizes = new Dictionary<int, string> { 
                                           { 20, "2XL" }, { 1, "S" },
                                           { 30, "5XL" }, { 10, "M" }
                                        };
    
     var sizes = mySizes.OrderBy(s => s.Key)
                        .Select(s => new {Size =  s.Value})
                        .ToList();
