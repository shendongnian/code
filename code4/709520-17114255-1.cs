    List<string> query = sqlOrderBy.AsEnumerable()
                                   .Reverse()
                                   .GroupBy(x => x.Split(' ')[0])
                                   .Select(g => g.First())
                                   .Reverse()
                                   .ToList();
