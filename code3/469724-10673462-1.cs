    var combined =
        Enumerable.Range(0, Data1.Count)
                  .Select(i => new
                  {
                      Item1 = Data1[i],
                      Item2 = Data2[i],
                      Item3 = Data3[i],
                  })
                  .OrderBy(c => c.Item1)
                  .ToList();
    Data1 = combined.Select(c => c.Item1).ToList();
    Data2 = combined.Select(c => c.Item2).ToList();
    Data3 = combined.Select(c => c.Item3).ToList();
