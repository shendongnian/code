    List<Tuple<string, string>> lst = new List<Tuple<string, string>>();
    lst.Add(new Tuple<string, string>("Some Class", "Default"));
    lst.Add(new Tuple<string, string>("Some Class", "Other"));
    lst.Add(new Tuple<string, string>("Some Class 2", "Default"));
    lst.Add(new Tuple<string, string>("Some Class 2", "Other"));
    lst.Add(new Tuple<string, string>("Some Class 3", "Default"));
    var dict = lst.GroupBy(g => g.Item1)
                  .ToDictionary(g => g.Key, k => k.Select(s => s.Item2)
                                                  .Where(p => p == "Other")
                                                  .DefaultIfEmpty("Default")
                                                  .First());
