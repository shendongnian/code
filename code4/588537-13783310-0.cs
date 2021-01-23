    int groupIndex = 0;
    List<List<string>> split = all.Select(s => {
                                       if (s.StartsWith("1."))
                                          groupIndex++;
                                       return new { groupIndex, s }; })
                                  .GroupBy(x => x.groupIndex)
                                  .Select(g => g.Select(x => x.s).ToList())
                                  .ToList();
