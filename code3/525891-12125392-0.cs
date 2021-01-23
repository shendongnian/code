    var groups =
      collection.GroupBy(x => x.GetType())
      .ToDictionary(g => g.Key, g => g.ToList());
    List<Foo> result = new List<Foo>();
    int max = groups.Values.Max(n => n.Count);
    for (int i = 0; i < max; i++) {
      foreach (Type  t in sortArray) {
        if (groups[t].Count > i) {
          result.Add(groups[t][i]);
        }
      }
    }
