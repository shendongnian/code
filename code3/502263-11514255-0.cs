        var trans = o.Aggregate
        (
                new {
                    List = new List<Tuple<int, List<int>>>(),
                                LastSeed = (int?)0
                },
                (acc, item) =>
                {
                    if (acc.LastSeed == null || item.A != acc.LastSeed)
                        acc.List.Add(Tuple.Create(item.A, new List<int>()));
                    acc.List[acc.List.Count - 1].Item2.Add(item.B);
                    return new { List = acc.List, LastSeed = (int?)item.A};
                },
                acc => acc.List.Select(
                      z=>new {A = z.Item1,
                              B = z.Item2 as IEnumerable<int>
                             })
           );
