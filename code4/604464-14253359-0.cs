    string line = "1,2,3,4";
    var splitted = line.Split(new[] {','}).Select((x, i) => new {
                                                                    Element = x,
                                                                    Index = i
                                                                })
                                          .GroupBy(x => x.Index / 1000)
                                          .Select(x => x.Select(y => y.Element).ToList())
                                          .ToList();
