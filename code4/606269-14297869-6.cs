    List<List<string>> eList = new List<List<string>>();
    eList.Add(new List<string>() { "a", "b" }); <--
    eList.Add(new List<string>() { "a", "c" });
    eList.Add(new List<string>() { "b", "a" }); <--
    var mergedList = eList.Select(x => new HashSet<string>(x))
                          .Distinct(HashSet<string>.CreateSetComparer()).ToList();
