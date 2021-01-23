    Dictionary<string, List<string>> d1 = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> d2 = new Dictionary<string, List<string>>();
    d2.ToList().ForEach(x =>
                             {
                               if (d1.ContainsKey(x.Key))
                                 d1[x.Key].AddRange(x.Value);
                               else
                                 d1.Add(x.Key, x.Value);
                             });
