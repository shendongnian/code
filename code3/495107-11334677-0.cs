    var numericPattern = new Regex(@"^-?\d+$");
    var result = list.Where(x => x != null && numericPattern.Matches(x))
                     .GroupBy(x => x, (key, group) => new { Value = group.Key, 
                                                            Count = group.Count() } )
                     .OrderByDescending(pair => pair.Count)
                     .First();
